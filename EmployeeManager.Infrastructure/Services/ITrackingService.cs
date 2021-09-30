using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManager.Infrastructure.Services
{

   public interface ITrackingService
    {
        public Task<List<TrackingResponse>> get();

        public Task<TrackingResponse> GetByID(int id);

        public Task<Tracking> Insert(TrackingInsertRequest request);
        public Task<Tracking> Update(int id, TrackingUpdateRequest request);
        public Task<Tracking> Delete(int id);


    }
}
