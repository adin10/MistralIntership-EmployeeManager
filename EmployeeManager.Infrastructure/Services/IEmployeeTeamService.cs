using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
   public interface IEmployeeTeamService
    {
        public Task<List<EmployeeTeam>> Get(EmployeeTeamSearchRequest search);
        public ValueTask<EmployeeTeam> GetById(int id);
        public Task<EmployeeTeam> Insert(EmployeeTeamInsertRequest request);
        public Task<EmployeeTeam> Update(int id, EmployeeTeamUpdateRequest request);

        public Task<EmployeeTeam> Delete(int id);
    }
}
