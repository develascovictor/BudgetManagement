using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class DeleteTransactionRequestValidator : BaseValidator<DeleteTransactionRequest>
    {
        public DeleteTransactionRequestValidator()
        {
            GetRequiredIntRule(nameof(DeleteTransactionRequest.Id), "id");
        }
    }
}