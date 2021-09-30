using AutoMapper;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Context;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public ProjectService(IMapper mapper, MyContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Project> Delete(int id)
        {
            var entity =await _context.Project.FindAsync(id);
            _context.Project.Remove(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ProjectResponse>> Get(ProjectSearchRequest search)
        {
            var query = _context.Project.AsQueryable();
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.ProjectName))
                {
                    var normalizedTeamName = search.ProjectName.ToLower();
                    query = query.Where(q => q.ProjectName.ToLower().Contains(normalizedTeamName));
                }

                if (search.FinishDateStartRange.HasValue)
                {
                    query = query.Where(q => q.FinishDate >= search.FinishDateStartRange);
                }
                if (search.FinishDateEndRange.HasValue)
                {
                    query = query.Where(q => q.FinishDate <= search.FinishDateEndRange);
                }
            }
            var list =await query.ToListAsync();
            return _mapper.Map<List<ProjectResponse>>(list);
        }

        public async Task<ProjectResponse> GetById(int id)
        {
             var entity=await _context.Project.Include(x=>x.ProjectTeams).FirstOrDefaultAsync(x=>x.ProjectID==id);
            return _mapper.Map<ProjectResponse>(entity);
            
        }

        public async Task<Project> Insert(ProjectInsertRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            // transaction koristimo kada imamo istovremeno dodavanje podataka dvije tabele u bazu
            try
            {
                var entity = _mapper.Map<Project>(request);
                await _context.Project.AddAsync(entity);
                await _context.SaveChangesAsync();

                //var projectTeam = request.Teams.Select(x => new ProjectTeam
                //{
                //    Project = entity,
                //    TeamID = x.TeamID
                //});
                var projectTeam = _mapper.Map<List<ProjectTeam>>(request.Teams);
                projectTeam.ForEach(x => x.Project = entity);
                await _context.ProjectTeam.AddRangeAsync(projectTeam);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Project> Update(int id, ProjectUpdateRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _context.Project.FindAsync(id);
                _mapper.Map(request, entity);
                await _context.SaveChangesAsync();
                var teams = await _context.ProjectTeam.Where(x => x.ProjectID == id).ToListAsync();

                var teamsToAdd = _mapper.Map<List<ProjectTeam>>(request.Teams.Where(x => !teams.Any(y => y.TeamID == x.TeamID)));
                teamsToAdd.ForEach(x => 
                {

                    x.Project = entity;
                    x.CreatedUserId = entity.CreatedUserId;
                    x.CreatedDate = DateTime.Now;
                });
                await _context.ProjectTeam.AddRangeAsync(teamsToAdd);

                var teasmsToDelete = teams.Where(x => !request.Teams.Any(y => y.TeamID == x.TeamID)).ToList();
                _context.ProjectTeam.RemoveRange(teasmsToDelete);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch(Exception ex)
            {
                
                await transaction.RollbackAsync();
                throw;
            }
         
        }
    }
}
