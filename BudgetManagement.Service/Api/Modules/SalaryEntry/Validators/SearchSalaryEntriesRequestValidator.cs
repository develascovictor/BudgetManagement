using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Validators
{
    public class SearchSalaryEntriesRequestValidator : BaseValidator<SearchSalaryEntriesRequest>
    {
        public SearchSalaryEntriesRequestValidator()
        {
        }
    }
}