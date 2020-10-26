using BudgetManagement.Service.Api.Modules.TransactionType.Models;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using BudgetManagement.Shared.Response.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.TransactionType.Interfaces
{
    public interface ITransactionTypeModule
    {
        Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken);

        Task<CommandResult<IReadOnlyCollection<TransactionTypeDto>>> ListTransactionTypesByBudgetIdAsync(GetTransactionTypesByBudgetIdRequest request, CancellationToken cancellationToken);
    }
}