using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Shared.Pagination.Models;

namespace BudgetManagement.Application.Interfaces
{
    public interface ISalaryEntryService
    {
        DataPage<SalaryEntry> SearchSalaryEntries(string filterOptions, string sortOptions, PageOptions pageOptions);
        SalaryEntry CreateSalaryEntry(SalaryEntryCreateDefinition salaryEntryCreateDefinition);
        SalaryEntry UpdateSalaryEntry(int id, SalaryEntryUpdateDefinition salaryEntryUpdateDefinition);
    }
}