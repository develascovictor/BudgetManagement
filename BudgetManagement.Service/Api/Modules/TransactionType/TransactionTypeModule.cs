using BudgetManagement.Service.Api.Modules.TransactionType.Interfaces;
using BudgetManagement.Service.Api.Modules.TransactionType.Models;
using BudgetManagement.Service.Api.Modules.TransactionType.Validators;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Response.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.TransactionType
{
    public class TransactionTypeModule : ITransactionTypeModule
    {
        private const string Version = "/v1";
        private const string Route = "/transactionType";
        private const int DefaultPageLimit = 100;

        private readonly ITransactionTypeModuleImpl _moduleImpl;

        public TransactionTypeModule(ITransactionTypeModuleImpl moduleImpl)
        {
            _moduleImpl = moduleImpl;
        }

        public async Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken)
        {
            var result = await _moduleImpl.HealthCheckAsync();
            return CommandResult<string>.Ok(result);
        }

        public async Task<CommandResult<IReadOnlyCollection<TransactionTypeDto>>> ListTransactionTypesByBudgetIdAsync(GetTransactionTypesByBudgetIdRequest request, CancellationToken cancellationToken)
        {
            var parameters = new { request, cancellationToken };

            try
            {
                if (request == null)
                {
                    return ExceptionExtensions.GetBadResponse<IReadOnlyCollection<TransactionTypeDto>>(parameters);
                }
            }

            catch (Exception e)
            {
                return e.GetBadResponse<IReadOnlyCollection<TransactionTypeDto>>(parameters);
            }

            var validator = new GetTransactionTypesByBudgetIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.GetBadResponse<IReadOnlyCollection<TransactionTypeDto>>(parameters);
            }

            try
            {
                var dtos = await _moduleImpl.ListTransactionTypesByBudgetIdAsync(request, cancellationToken);

                if (dtos == null)
                {
                    return CommandResult<IReadOnlyCollection<TransactionTypeDto>>.NotFound();
                }

                return CommandResult<IReadOnlyCollection<TransactionTypeDto>>.Ok(dtos);
            }

            catch (Exception e)
            {
                return e.GetInternalServerErrorResponse<IReadOnlyCollection<TransactionTypeDto>>(parameters);
            }
        }
    }
}