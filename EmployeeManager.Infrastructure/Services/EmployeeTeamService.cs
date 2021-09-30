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
    public class EmployeeTeamService : IEmployeeTeamService
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public EmployeeTeamService(IMapper mapper, MyContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<EmployeeTeam> Delete(int id)
        {
            var entity =await _context.EmployeeTeam.FindAsync(id);
            _context.EmployeeTeam.Remove(entity);
           await _context.SaveChangesAsync();
            return entity;

        }

        public Task<List<EmployeeTeam>> Get(EmployeeTeamSearchRequest search)
        {
            var query= _context.EmployeeTeam.Include(x=>x.Employee).Include(x=>x.Team).AsQueryable();
            if (search != null)
            {
                if (search.EmployeeID.HasValue)
                {
                    query = query.Where(q => q.EmployeeID == search.EmployeeID);
                }
            }
            var list = query.ToListAsync();
            return list;
        }

        public ValueTask<EmployeeTeam> GetById(int id)
        {
            return _context.EmployeeTeam.FindAsync(id);
            
        }

        public async Task<EmployeeTeam> Insert(EmployeeTeamInsertRequest request)
        {
            var entity = _mapper.Map<EmployeeTeam>(request);
           await _context.EmployeeTeam.AddAsync(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeTeam> Update(int id, EmployeeTeamUpdateRequest request)
        {
            var entity =await _context.EmployeeTeam.FindAsync(id);
            _mapper.Map(request, entity);
           await _context.SaveChangesAsync();
            return entity;
        }
    }
}
