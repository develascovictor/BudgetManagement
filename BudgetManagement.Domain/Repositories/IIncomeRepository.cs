using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Domain.Repositories
{
    public interface IIncomeRepository
    {
        Income Create(Income domain);
    }
}