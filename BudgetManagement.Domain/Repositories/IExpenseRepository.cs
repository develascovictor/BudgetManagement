using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Expense GetById(int id);
        Expense Create(Expense domain);
        Expense Update(Expense domain);
    }
}