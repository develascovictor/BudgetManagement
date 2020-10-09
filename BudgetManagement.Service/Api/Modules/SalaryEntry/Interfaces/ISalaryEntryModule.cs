using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.Response.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces
{
    public interface ISalaryEntryModule
    {
        Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken);
        Task<CommandResult<Page<SalaryEntryDto>>> SearchSalaryEntriesAsync(SearchSalaryEntriesRequest request, CancellationToken cancellationToken);
        Task<CommandResult<SalaryEntryDto>> CreateSalaryEntryAsync(CreateSalaryEntryRequest request, CancellationToken cancellationToken);
        Task<CommandResult<SalaryEntryDto>> UpdateSalaryEntryAsync(UpdateSalaryEntryRequest request, CancellationToken cancellationToken);
    }
}