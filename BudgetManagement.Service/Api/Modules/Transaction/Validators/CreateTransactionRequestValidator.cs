using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class CreateTransactionRequestValidator : BaseValidator<CreateTransactionRequest>
    {
        public CreateTransactionRequestValidator()
        {
            var twoDecimalExpression = new Regex(@"\d+(\.\d{1,2})?");

            GetRequiredIntRule(nameof(CreateTransactionRequest.BudgetId), "budgetId");
            GetInvalidNullableIntRule(nameof(CreateTransactionRequest.TransactionTypeId), "transactionTypeId");
            GetRequiredStringRule(nameof(CreateTransactionRequest.Description), "description");
            GetInvalidStringRule(nameof(CreateTransactionRequest.Description), "description", 50);
            GetInvalidStringRule(nameof(CreateTransactionRequest.Notes), "notes", 500);

            When(x => x.Expenses != null, () =>
            {
                RuleFor(x => x.Expenses)
                    .Cascade(CascadeMode.Stop)
                    .Must(x => x.Count <= 10).WithMessage("Only a max of 10 expenses at a time are allowed.");

                When(x => x.Expenses.Count > 0 && x.Expenses.Count <= 10, () =>
                {
                    RuleForEach(x => x.Expenses)
                        .Cascade(CascadeMode.Stop)
                        .Must(x => x != null).WithMessage("Element on 'expenses' parameter is null.")
                        .Must(x => x.Amount > 0).WithMessage("Element on 'expenses' parameter's 'amount' is less or equal to 0.")
                        //.Must(x => twoDecimalExpression.IsMatch(x.Amount.ToString())).WithMessage("Element on 'expenses' parameter's 'amount' has more than 2 decimals.")
                        .ScalePrecision(2, 10, ignoreTrailingZeros: true);

                    RuleForEach(x => x.Expenses)
                        .Cascade(CascadeMode.Stop)
                        .Must(x => x != null).WithMessage("Element on 'expenses' parameter is null.")
                        .Must(x => x.Rate > 0).WithMessage("Element on 'expenses' parameter's 'rate' is less or equal to 0.")
                        //.Must(x => twoDecimalExpression.IsMatch(x.Rate.ToString())).WithMessage("Element on 'expenses' parameter's 'rate' has more than 2 decimals.")
                        .ScalePrecision(2, 10, ignoreTrailingZeros: true);
                });
            });

            When(x => x.Incomes != null, () =>
            {
                RuleFor(x => x.Incomes)
                    .Cascade(CascadeMode.Stop)
                    .Must(x => x.Count <= 10).WithMessage("Only a max of 10 incomes at a time are allowed.");

                When(x => x.Incomes.Count > 0 && x.Incomes.Count <= 10, () =>
                {
                    RuleForEach(x => x.Incomes)
                        .Cascade(CascadeMode.Stop)
                        .Must(x => x != null).WithMessage("Element on 'incomes' parameter is null.")
                        .Must(x => x.Amount > 0).WithMessage("Element on 'incomes' parameter's 'amount' is less or equal to 0.")
                        //.Must(x => twoDecimalExpression.IsMatch(x.Amount.ToString())).WithMessage("Element on 'expenses' parameter's 'amount' has more than 2 decimals.")
                        .ScalePrecision(2, 10, ignoreTrailingZeros: true);

                    RuleForEach(x => x.Incomes)
                        .Cascade(CascadeMode.Stop)
                        .Must(x => x != null).WithMessage("Element on 'incomes' parameter is null.")
                        .Must(x => x.Rate > 0).WithMessage("Element on 'incomes' parameter's 'rate' is less or equal to 0.")
                        //.Must(x => twoDecimalExpression.IsMatch(x.Rate.ToString())).WithMessage("Element on 'incomes' parameter's 'rate' has more than 2 decimals.")
                        .ScalePrecision(2, 10, ignoreTrailingZeros: true);
                });
            });
        }
    }
}