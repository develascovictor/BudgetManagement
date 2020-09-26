using BudgetManagement.Service.Api.Modules.Budget.Models;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Budget.Interfaces
{
    public interface IBudgetModule
    {
        Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken);

        Task<CommandResult<Page<BudgetDto>>> SearchBudgetsAsync(SearchBudgetsRequest request, CancellationToken cancellationToken);
    }
}