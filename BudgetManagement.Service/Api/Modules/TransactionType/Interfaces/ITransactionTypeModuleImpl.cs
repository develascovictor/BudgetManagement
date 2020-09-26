using BudgetManagement.Service.Api.Modules.TransactionType.Models;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.TransactionType.Interfaces
{
    public interface ITransactionTypeModuleImpl
    {
        Task<string> HealthCheckAsync();

        Task<IReadOnlyCollection<TransactionTypeDto>> GetTransactionTypesByBudgetIdAsync(GetTransactionTypesByBudgetIdRequest request, CancellationToken cancellationToken);
    }
}