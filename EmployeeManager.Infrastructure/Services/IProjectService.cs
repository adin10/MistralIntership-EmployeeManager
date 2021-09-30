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
   public interface IProjectService
    {

        public Task<List<ProjectResponse>> Get(ProjectSearchRequest search);
        public Task<ProjectResponse> GetById(int id);
        public Task<Project> Insert(ProjectInsertRequest request);
        public Task<Project> Update(int id, ProjectUpdateRequest request);

        public Task<Project> Delete(int id);
    }
}
