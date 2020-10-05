using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Domain.Repositories
{
    public interface IIncomeRepository
    {
        Income GetById(int id);
        Income Create(Income domain);
        Income Update(Income domain);
    }
}