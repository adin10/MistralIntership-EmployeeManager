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

    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;
        public TeamService(MyContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TeamResponse>> Get(TeamSearchRequest search)
        {
            var query= _context.Team.AsQueryable();
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.TeamName))
                {
                    var normalizedTeamName = search.TeamName.ToLower();
                    query = query.Where(q => q.TeamName.ToLower().Contains(normalizedTeamName));
                }
            }
            var list =await query.ToListAsync();
            return _mapper.Map<List<TeamResponse>>(list);
        }

        public ValueTask<Team> GetByID(int id)
        {
            return _context.Team.FindAsync(id);
        }


        public async Task<Team> Delete(int id)
        {
            var entity= await _context.Team.FindAsync(id);
            _context.Team.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Team> Insert(TeamInsertRequest request)
        {
            var entity = _mapper.Map<Team>(request);
           await _context.Team.AddAsync(entity);
           await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Team> Update(int id, TeamUpdateRequest request)
        {
            var entity =await _context.Team.FindAsync(id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
