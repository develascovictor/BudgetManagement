using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Repositories
{
    public interface ISalaryEntryRepository
    {
        IEnumerable<SalaryEntry> Search(string filterOptions, string sortOptions, int index, int limit, out long total);
        SalaryEntry Create(SalaryEntry domain);
    }
}