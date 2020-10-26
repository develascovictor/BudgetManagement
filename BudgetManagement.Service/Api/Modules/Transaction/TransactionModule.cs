using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Validators;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using Filtering.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Transaction
{
    public class TransactionModule : ITransactionModule
    {
        private const string Version = "/v1";
        private const string Route = "/transaction";
        private const int DefaultPageLimit = 1000;

        private readonly ITransactionModuleImpl _moduleImpl;

        public TransactionModule(ITransactionModuleImpl moduleImpl)
        {
            _moduleImpl = moduleImpl;
        }

        public async Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken)
        {
            var result = await _moduleImpl.HealthCheckAsync();
            return CommandResult<string>.Ok(result);
        }

        public async Task<CommandResult<TransactionDto>> GetTransactionByIdAsync(GetTransactionByIdRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<TransactionDto>(parameters);
            }

            var validator = new GetTransactionByIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<TransactionDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.GetTransactionByIdAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<TransactionDto>.NotFound();
                }

                return CommandResult<TransactionDto>.Ok(dto);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<TransactionDto>(parameters);
            }
        }

        public async Task<CommandResult<Page<TransactionDto>>> SearchTransactionsByBudgetIdAsync(SearchTransactionsByBudgetIdRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<Page<TransactionDto>>(parameters);
                }

                //request.Filter = RequestExtensions.GetFilterRequest(Request.Url.Query);
                //parameters = new { request, cancellationToken };
            }

            catch (Exception e)
            {
                return e.GetBadResponse<Page<TransactionDto>>(parameters);
            }

            var validator = new SearchTransactionsByBudgetIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<Page<TransactionDto>>(parameters);
            }

            try
            {
                var paginationRequest = new PaginationRequest()
                {
                    Cursor = null,
                    Limit = DefaultPageLimit
                };
                var dtoPage = await _moduleImpl.SearchTransactionsByBudgetIdAsync(request, paginationRequest, cancellationToken);

                if (dtoPage == null)
                {
                    return CommandResult<Page<TransactionDto>>.NotFound();
                }

                return CommandResult<Page<TransactionDto>>.Ok(dtoPage);
            }

            catch (UnsupportedFilterPropertyException unsupportedFilterProperty)
            {
                return unsupportedFilterProperty.GetBadResponse<Page<TransactionDto>>(parameters);
            }

            catch (EntityPropertyNameNotDefinedException entityPropertyNameNotDefined)
            {
                return entityPropertyNameNotDefined.GetBadResponse<Page<TransactionDto>>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<Page<TransactionDto>>(parameters);
            }
        }

        public async Task<CommandResult<TransactionDto>> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<TransactionDto>(parameters);
            }

            var validator = new CreateTransactionRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<TransactionDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.CreateTransactionAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<TransactionDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(dto.Errors);
                }

                return CommandResult<TransactionDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<TransactionDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<TransactionDto>(parameters);
            }
        }

        public async Task<CommandResult<TransactionDto>> CreateTransactionAsync(CreateSalaryEntryTransactionRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<TransactionDto>(parameters);
            }

            var validator = new CreateSalaryEntryTransactionRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<TransactionDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.CreateTransactionAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<TransactionDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(dto.Errors);
                }

                return CommandResult<TransactionDto>.Created(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<TransactionDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<TransactionDto>(parameters);
            }
        }

        public async Task<CommandResult<TransactionDto>> UpdateTransactionAsync(UpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<TransactionDto>(parameters);
            }

            var validator = new UpdateTransactionRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<TransactionDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.UpdateTransactionAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<TransactionDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(dto.Errors);
                }

                return CommandResult<TransactionDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<TransactionDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<TransactionDto>(parameters);
            }
        }

        public async Task<CommandResult<TransactionDto>> DeleteTransactionAsync(DeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<TransactionDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<TransactionDto>(parameters);
            }

            var validator = new DeleteTransactionRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<TransactionDto>(parameters);
            }

            try
            {
                await _moduleImpl.DeleteTransactionAsync(request, cancellationToken);
                return CommandResult<TransactionDto>.Ok(null);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<TransactionDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<TransactionDto>(parameters);
            }
        }

        public async Task<CommandResult<ExpenseDto>> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<ExpenseDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<ExpenseDto>(parameters);
            }

            var validator = new CreateExpenseRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<ExpenseDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.CreateExpenseAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<ExpenseDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<ExpenseDto>(dto.Errors);
                }

                return CommandResult<ExpenseDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<ExpenseDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<ExpenseDto>(parameters);
            }
        }

        public async Task<CommandResult<ExpenseDto>> UpdateExpenseAsync(UpdateExpenseRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<ExpenseDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<ExpenseDto>(parameters);
            }

            var validator = new UpdateExpenseRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<ExpenseDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.UpdateExpenseAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<ExpenseDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<ExpenseDto>(dto.Errors);
                }

                return CommandResult<ExpenseDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<ExpenseDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<ExpenseDto>(parameters);
            }
        }

        public async Task<CommandResult<IncomeDto>> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<IncomeDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<IncomeDto>(parameters);
            }

            var validator = new CreateIncomeRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<IncomeDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.CreateIncomeAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<IncomeDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<IncomeDto>(dto.Errors);
                }

                return CommandResult<IncomeDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<IncomeDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<IncomeDto>(parameters);
            }
        }

        public async Task<CommandResult<IncomeDto>> UpdateIncomeAsync(UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<IncomeDto>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<IncomeDto>(parameters);
            }

            var validator = new UpdateIncomeRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<IncomeDto>(parameters);
            }

            try
            {
                var dto = await _moduleImpl.UpdateIncomeAsync(request, cancellationToken);

                if (dto == null)
                {
                    return CommandResult<IncomeDto>.NotFound();
                }

                if (dto.Errors.Any())
                {
                    return ExceptionExtensions.GetBadResponse<IncomeDto>(dto.Errors);
                }

                return CommandResult<IncomeDto>.Ok(dto);
            }

            catch (DomainException domainException)
            {
                //TODO: Make sure error code is displayed
                return domainException.GetBadResponse<IncomeDto>(parameters);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<IncomeDto>(parameters);
            }
        }
    }
}