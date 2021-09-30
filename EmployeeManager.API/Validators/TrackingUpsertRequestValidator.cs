using EmployeeManager.Infrastructure.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.API.Validators
{
    public class TrackingUpsertRequestValidator:AbstractValidator<TrackingInsertRequest>
    {
        public TrackingUpsertRequestValidator()
        {
            RuleFor(x => x.Date).NotNull().NotEmpty();
            RuleFor(x => x.WorkHours).NotNull().NotEmpty();
        }
    }
}
