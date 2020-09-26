using BudgetManagement.Service.Api.Modules.User.Interfaces;
using BudgetManagement.Service.Api.Modules.User.Models;
using BudgetManagement.Service.Api.Modules.User.Validators;
using BudgetManagement.Service.Api.Modules.User.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Response.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.User
{
    public class UserModule : IUserModule
    {
        private const string Version = "/v1";
        private const string Route = "/user";
        private const int DefaultPageLimit = 100;

        private readonly IUserModuleImpl _moduleImpl;

        public UserModule(IUserModuleImpl moduleImpl)
        {
            _moduleImpl = moduleImpl;
        }

        public async Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken)
        {
            var result = await _moduleImpl.HealthCheckAsync();
            return CommandResult<string>.Ok(result);
        }

        public async Task<CommandResult<UserDto>> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<UserDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<UserDto>(parameters);
            }

            var validator = new GetUserByIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<UserDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.GetUserByIdAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<UserDto>.NotFound();
                }

                return CommandResult<UserDto>.Ok(dto);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<UserDto>(parameters);
            }
        }
    }
}