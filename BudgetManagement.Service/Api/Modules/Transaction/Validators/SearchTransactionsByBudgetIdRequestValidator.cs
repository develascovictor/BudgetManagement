using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class SearchTransactionsByBudgetIdRequestValidator : BaseValidator<SearchTransactionsByBudgetIdRequest>
    {
        public SearchTransactionsByBudgetIdRequestValidator()
        {
            GetRequiredIntRule(nameof(SearchTransactionsByBudgetIdRequest.BudgetId), "budgetId");
        }
    }
}