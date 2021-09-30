using EmployeeManager.Database;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Validators
{
    public class ProjectUpsertRequestValidator:AbstractValidator<Project>
    {
        public ProjectUpsertRequestValidator()
        {
            RuleFor(x => x.ProjectName).NotNull().NotEmpty();
        }
    }
}
