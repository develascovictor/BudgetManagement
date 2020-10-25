using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.Server.Api.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces
{
    public interface ISalaryEntryModuleImpl
    {
        Task<string> HealthCheckAsync();
        Task<SalaryEntryDto> GetTransactionByIdAsync(GetSalaryEntryByIdRequest request, CancellationToken cancellationToken);
        Task<Page<SalaryEntryDto>> SearchSalaryEntriesAsync(SearchSalaryEntriesRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken);
        Task<SalaryEntryDto> CreateSalaryEntryAsync(CreateSalaryEntryRequest request, CancellationToken cancellationToken);
        Task<SalaryEntryDto> UpdateSalaryEntryAsync(UpdateSalaryEntryRequest request, CancellationToken cancellationToken);
    }
}