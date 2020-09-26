using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Expense Create(Expense domain);
    }
}