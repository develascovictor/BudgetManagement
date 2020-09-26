using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.Budget.Models;
using BudgetManagement.Service.Api.Modules.Budget.Validators;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using Filtering.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Budget
{
    public class BudgetModule : IBudgetModule
    {
        private const string Version = "/v1";
        private const string Route = "/budget";
        private const int DefaultPageLimit = 100;

        private readonly IBudgetModuleImpl _moduleImpl;

        public BudgetModule(IBudgetModuleImpl moduleImpl)
        {
            _moduleImpl = moduleImpl;
        }

        public async Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken)
        {
            var result = await _moduleImpl.HealthCheckAsync();
            return CommandResult<string>.Ok(result);
        }

        public async Task<CommandResult<Page<BudgetDto>>> SearchBudgetsAsync(SearchBudgetsRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<Page<BudgetDto>>(parameters);
                }

                //request.Filter = RequestExtensions.GetFilterRequest(Request.Url.Query);
                //parameters = new { request, cancellationToken };
            }

            catch (Exception e)
            {
                return e.GetBadResponse<Page<BudgetDto>>(parameters);
            }

            var validator = new SearchBudgetsRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<Page<BudgetDto>>(parameters);
            }

            try
            {
                var paginationRequest = new PaginationRequest()
                {
                    Cursor = null,
                    Limit = DefaultPageLimit
                };
                var dtoPage = await _moduleImpl.SearchBudgetsAsync(request, paginationRequest, cancellationToken);

                if (dtoPage == null)
                {
                    return CommandResult<Page<BudgetDto>>.NotFound();
                }

                return CommandResult<Page<BudgetDto>>.Ok(dtoPage);
            }

            catch (UnsupportedFilterPropertyException unsupportedFilterProperty)
            {
                return unsupportedFilterProperty.GetBadResponse<Page<BudgetDto>>(parameters);
            }

            catch (EntityPropertyNameNotDefinedException entityPropertyNameNotDefined)
            {
                return entityPropertyNameNotDefined.GetBadResponse<Page<BudgetDto>>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<Page<BudgetDto>>(parameters);
            }
        }
    }
}