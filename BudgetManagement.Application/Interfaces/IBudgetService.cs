using BudgetManagement.Domain.Entities;
using BudgetManagement.Shared.Pagination.Models;

namespace BudgetManagement.Application.Interfaces
{
    public interface IBudgetService
    {
        DataPage<Budget> SearchBudgets(string filterOptions, string sortOptions, PageOptions pageOptions);
    }
}