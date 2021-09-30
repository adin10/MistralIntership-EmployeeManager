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
    public interface ITeamService
    {
        public Task<List<TeamResponse>> Get(TeamSearchRequest search);
        public ValueTask<Team>  GetByID(int id);
        public Task<Team> Insert(TeamInsertRequest request);
        public Task<Team> Update(int id, TeamUpdateRequest request);
        public Task<Team> Delete(int id);
    }
}
