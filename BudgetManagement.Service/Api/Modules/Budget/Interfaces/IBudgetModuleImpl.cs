using BudgetManagement.Service.Api.Modules.Budget.Models;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Budget.Interfaces
{
    public interface IBudgetModuleImpl
    {
        Task<string> HealthCheckAsync();

        Task<Page<BudgetDto>> SearchBudgetsAsync(SearchBudgetsRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken);
    }
}