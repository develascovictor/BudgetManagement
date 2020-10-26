using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class DeleteExpenseRequestValidator : BaseValidator<DeleteExpenseRequest>
    {
        public DeleteExpenseRequestValidator()
        {
            GetRequiredIntRule(nameof(DeleteExpenseRequest.Id), "id");
        }
    }
}