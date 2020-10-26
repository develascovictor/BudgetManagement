using BudgetManagement.Service.Api.Modules.Transaction.Models;
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
        Task<CommandResult<TransactionDto>> CreateTransactionAsync(CreateTransactionRequest request, CancellationToken cancellationToken);
        Task<CommandResult<TransactionDto>> CreateTransactionAsync(CreateSalaryEntryTransactionRequest request, CancellationToken cancellationToken);
        Task<CommandResult<TransactionDto>> UpdateTransactionAsync(UpdateTransactionRequest request, CancellationToken cancellationToken);
        Task<CommandResult<TransactionDto>> DeleteTransactionAsync(DeleteTransactionRequest request, CancellationToken cancellationToken);
        Task<CommandResult<ExpenseDto>> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken);
        Task<CommandResult<ExpenseDto>> UpdateExpenseAsync(UpdateExpenseRequest request, CancellationToken cancellationToken);
        Task<CommandResult<ExpenseDto>> DeleteExpenseAsync(DeleteExpenseRequest request, CancellationToken cancellationToken);
        Task<CommandResult<IncomeDto>> CreateIncomeAsync(CreateIncomeRequest request, CancellationToken cancellationToken);
        Task<CommandResult<IncomeDto>> UpdateIncomeAsync(UpdateIncomeRequest request, CancellationToken cancellationToken);
        Task<CommandResult<IncomeDto>> DeleteIncomeAsync(DeleteIncomeRequest request, CancellationToken cancellationToken);
    }
}