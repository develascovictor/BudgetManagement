using BudgetManagement.Application;
using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Shared.Extensions;
using log4net;
using System.Data.Entity.Validation;
using System.Reflection;

namespace BudgetManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IBudgetManagementContext _context;

        private IBudgetRepository _budgetRepository;
        private IExpenseRepository _expenseRepository;
        private IIncomeRepository _incomeRepository;
        private ISalaryEntryRepository _salaryEntryRepository;
        private ITransactionRepository _transactionRepository;
        private ITransactionTypeRepository _transactionTypeRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(IBudgetManagementContext context)
        {
            _context = context;
        }

        public IBudgetRepository BudgetRepository =>
            _budgetRepository ??
            (_budgetRepository = new BudgetRepository(_context));

        public IExpenseRepository ExpenseRepository =>
            _expenseRepository ??
            (_expenseRepository = new ExpenseRepository(_context));

        public IIncomeRepository IncomeRepository =>
            _incomeRepository ??
            (_incomeRepository = new IncomeRepository(_context));

        public ISalaryEntryRepository SalaryEntryRepository =>
            _salaryEntryRepository ??
            (_salaryEntryRepository = new SalaryEntryRepository(_context));

        public ITransactionRepository TransactionRepository =>
            _transactionRepository ??
            (_transactionRepository = new TransactionRepository(_context));

        public ITransactionTypeRepository TransactionTypeRepository =>
            _transactionTypeRepository ??
            (_transactionTypeRepository = new TransactionTypeRepository(_context));

        public IUserRepository UserRepository =>
            _userRepository ??
            (_userRepository = new UserRepository(_context));

        public void SaveChanges()
        {
            try
            {
                var changes = _context.SaveChanges();
                Log.Debug($"{changes} changes persisted.");
            }

            catch (DbEntityValidationException dve)
            {
                dve.GetErrorLogResult(null);
                throw;
            }
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}