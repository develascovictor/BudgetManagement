using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class CreateTransactionRequestValidator : BaseValidator<CreateTransactionRequest>
    {
        public CreateTransactionRequestValidator()
        {
            //GetRequiredIntRule(nameof(CreateTransactionRequest.TransactionId), "transactionId");
            //GetRequiredMoneyRule(nameof(CreateTransactionRequest.Amount), "amount");
            //GetRequiredMoneyRule(nameof(CreateTransactionRequest.Rate), "rate");
        }
    }
}