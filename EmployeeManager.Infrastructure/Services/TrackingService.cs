using AutoMapper;
using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Context;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public TrackingService(MyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Tracking> Delete(int id)
        {
            var entity = await _context.Tracking.FindAsync(id);
            _context.Tracking.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TrackingResponse>> get()
        {
            var list = await _context.Tracking.Include(q=>q.ProjectTeam).ThenInclude(q=>q.Team).Include(q=>q.ProjectTeam).ThenInclude(q=>q.Project).ToListAsync();
            return _mapper.Map<List<TrackingResponse>>(list);
        }
        public async Task<TrackingResponse> GetByID(int id)
        {
            var result = await _context.Tracking.Include(x=>x.EmployeeTeam).Include(x=>x.ProjectTeam).FirstOrDefaultAsync(x => x.TrackingID == id);
            return _mapper.Map<TrackingResponse>(result);
        }

        public async Task<Tracking> Insert(TrackingInsertRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = _mapper.Map<Tracking>(request);
                await _context.Tracking.AddAsync(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
           
        }

        public async Task<Tracking> Update(int id, TrackingUpdateRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _context.Tracking.FindAsync(id);
                _mapper.Map(request, entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return entity;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            
        }
    }
}
