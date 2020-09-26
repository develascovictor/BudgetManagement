using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Budget.Validators
{
    public class SearchBudgetsRequestValidator : BaseValidator<SearchBudgetsRequest>
    {
        public SearchBudgetsRequestValidator()
        {
        }
    }
}