using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Repositories
{
    public interface ITransactionTypeRepository
    {
        IEnumerable<TransactionType> GetByBudgetId(int budgetId);
        TransactionType GetById(int id);
    }
}