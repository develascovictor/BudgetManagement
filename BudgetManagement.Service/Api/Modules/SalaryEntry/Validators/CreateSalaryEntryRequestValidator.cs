using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Validators
{
    public class CreateSalaryEntryRequestValidator : BaseValidator<CreateSalaryEntryRequest>
    {
        public CreateSalaryEntryRequestValidator()
        {
            GetRequiredIntRule(nameof(CreateSalaryEntryRequest.UserId), "userId");
            GetRequiredMoneyRule(nameof(CreateSalaryEntryRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(CreateSalaryEntryRequest.Rate), "rate");
        }
    }
}