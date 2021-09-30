using EmployeeManager.Infrastructure.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Validators
{
    public class EmployeeTeamUpsertRequestValidator:AbstractValidator<EmployeeTeamInsertRequest>
    {
        public EmployeeTeamUpsertRequestValidator()
        {
            //RuleFor(x => x.EmployeeID).NotEmpty().NotNull();
            RuleFor(x => x.TeamID).NotEmpty().NotNull();
        }
    }
}
