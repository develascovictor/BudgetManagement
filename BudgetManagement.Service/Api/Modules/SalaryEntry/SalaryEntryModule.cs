using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Validators;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using Filtering.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry
{
    public class SalaryEntryModule : ISalaryEntryModule
    {
        private const string Version = "/v1";
        private const string Route = "/salaryEntry";
        private const int DefaultPageLimit = 100;

        private readonly ISalaryEntryModuleImpl _moduleImpl;

        public SalaryEntryModule(ISalaryEntryModuleImpl moduleImpl)
        {
            _moduleImpl = moduleImpl;
        }

        public async Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken)
        {
            var result = await _moduleImpl.HealthCheckAsync();
            return CommandResult<string>.Ok(result);
        }

        public async Task<CommandResult<Page<SalaryEntryDto>>> SearchSalaryEntriesAsync(SearchSalaryEntriesRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<Page<SalaryEntryDto>>(parameters);
                }

                //request.Filter = RequestExtensions.GetFilterRequest(Request.Url.Query);
                //parameters = new { request, cancellationToken };
            }

            catch (Exception e)
            {
                return e.GetBadResponse<Page<SalaryEntryDto>>(parameters);
            }

            var validator = new SearchSalaryEntriesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<Page<SalaryEntryDto>>(parameters);
            }

            try
            {
                var paginationRequest = new PaginationRequest()
                {
                    Cursor = null,
                    Limit = DefaultPageLimit
                };
                var dtoPage = await _moduleImpl.SearchSalaryEntriesAsync(request, paginationRequest, cancellationToken);

                if (dtoPage == null)
                {
                    return CommandResult<Page<SalaryEntryDto>>.NotFound();
                }

                return CommandResult<Page<SalaryEntryDto>>.Ok(dtoPage);
            }

            catch (UnsupportedFilterPropertyException unsupportedFilterProperty)
            {
                return unsupportedFilterProperty.GetBadResponse<Page<SalaryEntryDto>>(parameters);
            }

            catch (EntityPropertyNameNotDefinedException entityPropertyNameNotDefined)
            {
                return entityPropertyNameNotDefined.GetBadResponse<Page<SalaryEntryDto>>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<Page<SalaryEntryDto>>(parameters);
            }
        }

        public async Task<CommandResult<SalaryEntryDto>> CreateSalaryEntryAsync(CreateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<SalaryEntryDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<SalaryEntryDto>(parameters);
            }

            var validator = new CreateSalaryEntryRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<SalaryEntryDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.CreateSalaryEntryAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<SalaryEntryDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<SalaryEntryDto>(dto.Errors);
                }

                return CommandResult<SalaryEntryDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<SalaryEntryDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<SalaryEntryDto>(parameters);
            }
        }

        public async Task<CommandResult<SalaryEntryDto>> UpdateSalaryEntryAsync(UpdateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<SalaryEntryDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<SalaryEntryDto>(parameters);
            }

            var validator = new UpdateSalaryEntryRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<SalaryEntryDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.UpdateSalaryEntryAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<SalaryEntryDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<SalaryEntryDto>(dto.Errors);
                }

                return CommandResult<SalaryEntryDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<SalaryEntryDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<SalaryEntryDto>(parameters);
            }
        }
    }
}