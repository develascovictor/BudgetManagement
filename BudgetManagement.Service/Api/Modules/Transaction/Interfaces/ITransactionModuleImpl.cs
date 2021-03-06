﻿using BudgetManagement.Service.Api.Modules.Transaction.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Transaction.Interfaces
{
    public interface ITransactionModuleImpl
    {
        Task<string> HealthCheckAsync();

        Task<TransactionDto> GetTransactionByIdAsync(GetTransactionByIdRequest request, CancellationToken cancellationToken);

        Task<Page<TransactionDto>> SearchTransactionsByBudgetIdAsync(SearchTransactionsByBudgetIdRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken);

        Task<ExpenseDto> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken);

        Task<IncomeDto> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken);
    }
}