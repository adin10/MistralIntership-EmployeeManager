using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using EmployeeManager.Infrastructure.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeResponse>> Get(EmployeeSearchRequest search);
        public Task<EmployeeResponse> GetByID(int id);

        public Task<Employee> Insert(EmployeeInsertRequest request);
        public Task<Employee> Update(int id, EmployeeUpdateRequest request);

        public Task<Employee> Delete(int id);
    }
}
