using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.Transaction.Validators
{
    public class GetTransactionByIdRequestValidator : BaseValidator<GetTransactionByIdRequest>
    {
        public GetTransactionByIdRequestValidator()
        {
            GetRequiredIntRule(nameof(GetTransactionByIdRequest.Id), "id");
        }
    }
}