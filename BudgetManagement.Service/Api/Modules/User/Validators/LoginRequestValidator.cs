using BudgetManagement.Service.Api.Modules.User.Views;
using BudgetManagement.Shared.FluentValidation;

namespace BudgetManagement.Service.Api.Modules.User.Validators
{
    public class LoginRequestValidator : BaseValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            GetRequiredStringRule(nameof(LoginRequest.UserName), "userName");
            GetInvalidStringRule(nameof(LoginRequest.UserName), "userName", 20);
            GetRequiredStringRule(nameof(LoginRequest.Password), "password");
            GetInvalidStringRule(nameof(LoginRequest.Password), "password", 20);
        }
    }
}