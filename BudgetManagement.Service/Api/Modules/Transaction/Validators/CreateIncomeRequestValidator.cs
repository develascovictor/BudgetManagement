using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class CreateIncomeRequestValidator : BaseValidator<CreateIncomeRequest>
    {
        public CreateIncomeRequestValidator()
        {
            GetRequiredIntRule(nameof(CreateIncomeRequest.TransactionId), "transactionId");
            GetRequiredMoneyRule(nameof(CreateIncomeRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(CreateIncomeRequest.Rate), "rate");
            GetRequiredDateRule(nameof(CreateIncomeRequest.Date), "date");
        }
    }
}