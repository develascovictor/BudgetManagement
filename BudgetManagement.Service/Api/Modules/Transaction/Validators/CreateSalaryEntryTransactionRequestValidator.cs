using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class CreateSalaryEntryTransactionRequestValidator : BaseValidator<CreateSalaryEntryTransactionRequest>
    {
        public CreateSalaryEntryTransactionRequestValidator()
        {
            GetRequiredIntRule(nameof(CreateSalaryEntryTransactionRequest.SalaryEntryId), "salaryEntryId");
            GetRequiredIntRule(nameof(CreateSalaryEntryTransactionRequest.BudgetId), "budgetId");
            GetRequiredMoneyRule(nameof(CreateSalaryEntryTransactionRequest.Amount), "amount");
            GetRequiredMoneyRule(nameof(CreateSalaryEntryTransactionRequest.Rate), "rate");
        }
    }
}