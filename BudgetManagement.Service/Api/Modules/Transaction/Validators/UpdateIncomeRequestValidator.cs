using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class UpdateIncomeRequestValidator : BaseValidator<UpdateIncomeRequest>
    {
        public UpdateIncomeRequestValidator()
        {
            GetRequiredIntRule(nameof(UpdateIncomeRequest.Id), "id");
            GetRequiredMoneyRule(nameof(UpdateIncomeRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(UpdateIncomeRequest.Rate), "rate");
            GetRequiredDateRule(nameof(UpdateIncomeRequest.Date), "date");
        }
    }
}