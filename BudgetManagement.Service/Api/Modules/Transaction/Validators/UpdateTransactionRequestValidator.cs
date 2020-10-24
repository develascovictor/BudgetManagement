using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class UpdateTransactionRequestValidator : BaseValidator<UpdateTransactionRequest>
    {
        public UpdateTransactionRequestValidator()
        {
            GetInvalidNullableIntRule(nameof(UpdateTransactionRequest.TransactionTypeId), "transactionTypeId");
            GetRequiredStringRule(nameof(UpdateTransactionRequest.Description), "description");
            GetInvalidStringRule(nameof(UpdateTransactionRequest.Description), "description", 50);
            GetInvalidStringRule(nameof(UpdateTransactionRequest.Notes), "notes", 500);
            GetRequiredDateRule(nameof(UpdateTransactionRequest.Date), "date");
        }
    }
}