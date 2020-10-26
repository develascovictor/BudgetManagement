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
            new CreateSalaryEntryTransactionRequestProfile(),
            new CreateTransactionRequestProfile(),
            new ExpenseDtoProfile(),
            new IncomeDtoProfile(),
            new TransactionDtoProfile(),
            new UpdateExpenseRequestProfile(),
            new UpdateIncomeRequestProfile()
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

        public async Task<TransactionDto> CreateTransactionAsync(CreateSalaryEntryTransactionRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunRequestAndDispatchEventAsync<CreateSalaryEntryTransactionRequest, SalaryEntryTransactionCreateDefinition>(x => _transactionService.CreateTransaction(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<TransactionDto> UpdateTransactionAsync(UpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunRequestAndDispatchEventAsync<UpdateTransactionRequest, TransactionUpdateDefinition>(x => _transactionService.UpdateTransaction(request.Id, x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task DeleteTransactionAsync(DeleteTransactionRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            await RunAction(() => _transactionService.DeleteTransaction(request.Id), caller.Method, cancellationToken);
        }

        public async Task<ExpenseDto> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<CreateExpenseRequest, ExpenseCreateDefinition, ExpenseDto, Domain.Entities.Expense>(x => _transactionService.CreateExpense(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<ExpenseDto> UpdateExpenseAsync(UpdateExpenseRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<UpdateExpenseRequest, ExpenseUpdateDefinition, ExpenseDto, Domain.Entities.Expense>(x => _transactionService.UpdateExpense(request.Id, x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task DeleteExpenseAsync(DeleteExpenseRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            await RunAction(() => _transactionService.DeleteExpense(request.Id), caller.Method, cancellationToken);
        }

        public async Task<IncomeDto> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<CreateIncomeRequest, IncomeCreateDefinition, IncomeDto, Domain.Entities.Income>(x => _transactionService.CreateIncome(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<IncomeDto> UpdateIncomeAsync(UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunAlternateRequestAndDispatchEventAsync<UpdateIncomeRequest, IncomeUpdateDefinition, IncomeDto, Domain.Entities.Income>(x => _transactionService.UpdateIncome(request.Id, x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task DeleteIncomeAsync(DeleteIncomeRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            await RunAction(() => _transactionService.DeleteIncome(request.Id), caller.Method, cancellationToken);
        }
    }
}