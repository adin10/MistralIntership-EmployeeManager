using EmployeeManager.Infrastructure.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Validators
{
    public class TeamUpsertRequestValidator: AbstractValidator<TeamInsertRequest>
    {
        public TeamUpsertRequestValidator()
        {
            RuleFor(x => x.TeamName).NotNull().NotEmpty();
        }
    }
}
