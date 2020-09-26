using BudgetManagement.Domain.Repositories;
using System;

namespace BudgetManagement.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IBudgetRepository BudgetRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        IIncomeRepository IncomeRepository { get; }
        ISalaryEntryRepository SalaryEntryRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ITransactionTypeRepository TransactionTypeRepository { get; }
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}