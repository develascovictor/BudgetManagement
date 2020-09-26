using BudgetManagement.Service.Api.Modules.User.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.User.Validators
{
    public class GetUserByIdRequestValidator : BaseValidator<GetUserByIdRequest>
    {
        public GetUserByIdRequestValidator()
        {
            GetRequiredIntRule(nameof(GetUserByIdRequest.Id), "id");
        }
    }
}