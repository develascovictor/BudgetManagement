﻿using BudgetManagement.Service.Api.Modules.Transaction.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Transaction.Interfaces
{
    public interface ITransactionModule
    {
        Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken);

        Task<CommandResult<TransactionDto>> GetTransactionByIdAsync(GetTransactionByIdRequest request, CancellationToken cancellationToken);

        Task<CommandResult<Page<TransactionDto>>> SearchTransactionsByBudgetIdAsync(SearchTransactionsByBudgetIdRequest request, CancellationToken cancellationToken);

        Task<CommandResult<ExpenseDto>> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken);

        Task<CommandResult<IncomeDto>> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken);
    }
}