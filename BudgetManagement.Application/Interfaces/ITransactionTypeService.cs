using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Application.Interfaces
{
    public interface ITransactionTypeService
    {
        IReadOnlyCollection<TransactionType> GetTransactionTypesByBudgetId(int budgetId);
    }
}