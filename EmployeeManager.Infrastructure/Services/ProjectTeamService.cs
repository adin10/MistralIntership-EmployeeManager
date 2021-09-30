using AutoMapper;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Context;
using EmployeeManager.Infrastructure.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
    public class ProjectTeamService : IProjectTeamService
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public ProjectTeamService(IMapper mapper, MyContext context)
        {
            _mapper = mapper;
            _context = context;
        }

     

        public Task<List<ProjectTeam>> Get(ProjectTeamSearchRequest search)
        {
            var query= _context.ProjectTeam.Include(x => x.Project).Include(x => x.Team).AsQueryable();
            if (search != null)
            {
                if (search.TeamID.HasValue)
                {
                    query = query.Where(q => q.TeamID == search.TeamID);
                }
            }
            var list = query.ToListAsync();
            return list;
        }

        public ValueTask<ProjectTeam> GetById(int id)
        {
            return _context.ProjectTeam.FindAsync(id);
            
        }

        public async Task<ProjectTeam> Insert(ProjectTeamInsertRequest request)
        {
            var entity = _mapper.Map<ProjectTeam>(request);
           await _context.ProjectTeam.AddAsync(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProjectTeam> Update(int id, ProjectTeamUpdateRequest request)
        {
            var entity =await _context.ProjectTeam.FindAsync(id);
            _mapper.Map(request, entity);
           await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<ProjectTeam> Delete(int id)
        {
            var entity =await _context.ProjectTeam.FindAsync(id);
            _context.ProjectTeam.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
