using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class UpdateExpenseRequestValidator : BaseValidator<UpdateExpenseRequest>
    {
        public UpdateExpenseRequestValidator()
        {
            GetRequiredIntRule(nameof(UpdateExpenseRequest.Id), "id");
            GetRequiredMoneyRule(nameof(UpdateExpenseRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(UpdateExpenseRequest.Rate), "rate");
        }
    }
}