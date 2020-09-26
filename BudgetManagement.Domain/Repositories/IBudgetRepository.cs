using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Repositories
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> Search(string filterOptions, string sortOptions, int index, int limit, out long total);
    }
}