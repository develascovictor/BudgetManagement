using BudgetManagement.Domain.Entities;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Repositories
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> GetBySalaryEntryId(int salaryEntryId);
        Income GetById(int id);
        Income Create(Income domain);
        Income Update(Income domain);
        void Delete(Income domain);
        void Delete(IEnumerable<Income> domains);
    }
}