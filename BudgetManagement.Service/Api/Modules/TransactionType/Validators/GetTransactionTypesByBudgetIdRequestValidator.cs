using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.TransactionType.Validators
{
    public class GetTransactionTypesByBudgetIdRequestValidator : BaseValidator<GetTransactionTypesByBudgetIdRequest>
    {
        public GetTransactionTypesByBudgetIdRequestValidator()
        {
            GetRequiredIntRule(nameof(GetTransactionTypesByBudgetIdRequest.BudgetId), "budgetId");
        }
    }
}