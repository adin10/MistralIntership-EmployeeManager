using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Validators
{
    public class ProjectTeamUpsertRequestValidator:AbstractValidator<ProjectTeamInsertRequest>
    {
        public ProjectTeamUpsertRequestValidator()
        {
            //RuleFor(x => x.ProjectID).NotNull().NotEmpty();
            RuleFor(x => x.TeamID).NotNull().NotEmpty();
        }
    }
}
