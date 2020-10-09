using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Validators
{
    public class UpdateSalaryEntryRequestValidator : BaseValidator<UpdateSalaryEntryRequest>
    {
        public UpdateSalaryEntryRequestValidator()
        {
            GetRequiredIntRule(nameof(UpdateSalaryEntryRequest.Id), "id");
            GetRequiredMoneyRule(nameof(UpdateSalaryEntryRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(UpdateSalaryEntryRequest.Rate), "rate");
        }
    }
}