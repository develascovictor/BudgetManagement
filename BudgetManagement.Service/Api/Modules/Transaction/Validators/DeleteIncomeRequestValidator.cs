using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class DeleteIncomeRequestValidator : BaseValidator<DeleteIncomeRequest>
    {
        public DeleteIncomeRequestValidator()
        {
            GetRequiredIntRule(nameof(DeleteIncomeRequest.Id), "id");
        }
    }
}