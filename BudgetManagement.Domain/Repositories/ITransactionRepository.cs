using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Transaction GetById(int id);
        IEnumerable<Transaction> SearchByBudgetId(int budgetId, string filterOptions, string sortOptions, int index, int limit, out long total);
    }
}