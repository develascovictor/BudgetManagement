using AutoMapper;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Models;
using BudgetManagement.Service.Api.Modules.Base;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Mapping;
using BudgetManagement.Service.Api.Modules.Transaction.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Server.Api.Pagination;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Transaction
{
    public class TransactionModuleImpl : BaseEventModuleImpl<Domain.Entities.Transaction, int, TransactionDto, TransactionDto>, ITransactionModuleImpl
    {
        private readonly ITransactionService _transactionService;

        private static readonly List<Profile> Profiles = new List<Profile>
        {
            new CreateExpenseRequestProfile(),
            new CreateIncomeRequestProfile(),
            new CreateTransactionRequestProfile(),
            new ExpenseDtoProfile(),
            new IncomeDtoProfile(),
            new TransactionDtoProfile()
        };

        private static readonly IConfigurationProvider MapperConfigurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            Profiles.ForEach(cfg.AddProfile);
        });

        public TransactionModuleImpl(ITransactionService transactionService)
            : base(null, MapperConfigurationProvider)
        {
            _transactionService = transactionService;
        }

        public async Task<string> HealthCheckAsync()
        {
            return await Task.FromResult($"Status: Transaction Healthy [{DateTime.UtcNow:O}]");
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(GetTransactionByIdRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await GetByIdAsync(() => _transactionService.GetTransactionById(request.Id), caller.Method, cancellationToken);

            return dto;
        }

        public async Task<Page<TransactionDto>> SearchTransactionsByBudgetIdAsync(SearchTransactionsByBudgetIdRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var pageDto = await SearchAsync((pageOptions) => _transactionService.SearchTransactionsByBudgetId(request.BudgetId, request.Filter, request.Sort, pageOptions), paginationRequest, caller.Method, cancellationToken);

            return pageDto;
        }

        public async Task<TransactionDto> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunRequestAndDispatchEventAsync<CreateTransactionRequest, TransactionCreateDefinition>(x => _transactionService.CreateTransaction(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<ExpenseDto> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<CreateExpenseRequest, ExpenseCreateDefinition, ExpenseDto, Domain.Entities.Expense>(x => _transactionService.CreateExpense(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<IncomeDto> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<CreateIncomeRequest, IncomeCreateDefinition, IncomeDto, Domain.Entities.Income>(x => _transactionService.CreateIncome(x), request, caller.Method, cancellationToken);

            return dto;
        }
    }
}