using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Validators
{
    public class GetSalaryEntryByIdRequestValidator : BaseValidator<GetSalaryEntryByIdRequest>
    {
        public GetSalaryEntryByIdRequestValidator()
        {
            GetRequiredIntRule(nameof(GetSalaryEntryByIdRequest.Id), "id");
        }
    }
}