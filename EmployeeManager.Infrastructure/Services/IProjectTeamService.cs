using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Services
{
   public interface IProjectTeamService
    {
        public Task<List<ProjectTeam>> Get(ProjectTeamSearchRequest search);

        public ValueTask<ProjectTeam> GetById(int id);
        public Task<ProjectTeam> Insert(ProjectTeamInsertRequest request);

        public Task<ProjectTeam> Update(int id, ProjectTeamUpdateRequest request);
        public Task<ProjectTeam> Delete(int id);
    }
}
