using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class CreateExpenseRequestValidator : BaseValidator<CreateExpenseRequest>
    {
        public CreateExpenseRequestValidator()
        {
            GetRequiredIntRule(nameof(CreateExpenseRequest.TransactionId), "transactionId");
            GetRequiredMoneyRule(nameof(CreateExpenseRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(CreateExpenseRequest.Rate), "rate");
        }
    }
}