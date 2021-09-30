using EmployeeManager.Infrastructure.Requests;
using FluentValidation;

namespace EmployeeManager.API.Validators
{
    public class EmployeeUpsertRequestValidator : AbstractValidator<EmployeeInsertRequest>
    {
        public EmployeeUpsertRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
        }
    }
}
