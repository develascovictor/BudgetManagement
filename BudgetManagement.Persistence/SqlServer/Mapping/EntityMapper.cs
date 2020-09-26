using AutoMapper;
using System.Collections.Generic;
using System.Reflection;

namespace BudgetManagement.Persistence.SqlServer.Mapping
{
    public static class EntityMapper
    {
        private static readonly IMapper MapperInstance;

        static EntityMapper()
        {
            var assembly = Assembly.GetAssembly(typeof(EntityMapper));
            var config = new MapperConfiguration(cfg => cfg.AddMaps(assembly));
            config.AssertConfigurationIsValid();

            MapperInstance = new Mapper(config);
        }

        #region Budget

        public static Domain.Entities.Budget ToDomain(Budget entity)
        {
            return MapperInstance.Map<Budget, Domain.Entities.Budget>(entity);
        }

        public static IEnumerable<Domain.Entities.Budget> ToDomain(IEnumerable<Budget> entities)
        {
            return MapperInstance.Map<IEnumerable<Budget>, IEnumerable<Domain.Entities.Budget>>(entities);
        }

        public static Budget ToPersistence(Domain.Entities.Budget domain)
        {
            return MapperInstance.Map<Domain.Entities.Budget, Budget>(domain);
        }

        #endregion

        #region Expense

        public static Domain.Entities.Expense ToDomain(Expense entity)
        {
            return MapperInstance.Map<Expense, Domain.Entities.Expense>(entity);
        }

        public static IEnumerable<Domain.Entities.Expense> ToDomain(IEnumerable<Expense> entities)
        {
            return MapperInstance.Map<IEnumerable<Expense>, IEnumerable<Domain.Entities.Expense>>(entities);
        }

        public static Expense ToPersistence(Domain.Entities.Expense domain)
        {
            return MapperInstance.Map<Domain.Entities.Expense, Expense>(domain);
        }

        #endregion

        #region Income

        public static Domain.Entities.Income ToDomain(Income entity)
        {
            return MapperInstance.Map<Income, Domain.Entities.Income>(entity);
        }

        public static IEnumerable<Domain.Entities.Income> ToDomain(IEnumerable<Income> entities)
        {
            return MapperInstance.Map<IEnumerable<Income>, IEnumerable<Domain.Entities.Income>>(entities);
        }

        public static Income ToPersistence(Domain.Entities.Income domain)
        {
            return MapperInstance.Map<Domain.Entities.Income, Income>(domain);
        }

        #endregion

        #region Salary Entry

        public static Domain.Entities.SalaryEntry ToDomain(SalaryEntry entity)
        {
            return MapperInstance.Map<SalaryEntry, Domain.Entities.SalaryEntry>(entity);
        }

        public static IEnumerable<Domain.Entities.SalaryEntry> ToDomain(IEnumerable<SalaryEntry> entities)
        {
            return MapperInstance.Map<IEnumerable<SalaryEntry>, IEnumerable<Domain.Entities.SalaryEntry>>(entities);
        }

        public static SalaryEntry ToPersistence(Domain.Entities.SalaryEntry domain)
        {
            return MapperInstance.Map<Domain.Entities.SalaryEntry, SalaryEntry>(domain);
        }

        #endregion

        #region Transaction

        public static Domain.Entities.Transaction ToDomain(Transaction entity)
        {
            return MapperInstance.Map<Transaction, Domain.Entities.Transaction>(entity);
        }

        public static IEnumerable<Domain.Entities.Transaction> ToDomain(IEnumerable<Transaction> entities)
        {
            return MapperInstance.Map<IEnumerable<Transaction>, IEnumerable<Domain.Entities.Transaction>>(entities);
        }

        public static Transaction ToPersistence(Domain.Entities.Transaction domain)
        {
            return MapperInstance.Map<Domain.Entities.Transaction, Transaction>(domain);
        }

        #endregion

        #region Transaction Type

        public static Domain.Entities.TransactionType ToDomain(TransactionType entity)
        {
            return MapperInstance.Map<TransactionType, Domain.Entities.TransactionType>(entity);
        }

        public static IEnumerable<Domain.Entities.TransactionType> ToDomain(IEnumerable<TransactionType> entities)
        {
            return MapperInstance.Map<IEnumerable<TransactionType>, IEnumerable<Domain.Entities.TransactionType>>(entities);
        }

        public static TransactionType ToPersistence(Domain.Entities.TransactionType domain)
        {
            return MapperInstance.Map<Domain.Entities.TransactionType, TransactionType>(domain);
        }

        #endregion

        #region User

        public static Domain.Entities.User ToDomain(User entity)
        {
            return MapperInstance.Map<User, Domain.Entities.User>(entity);
        }

        public static IEnumerable<Domain.Entities.User> ToDomain(IEnumerable<User> entities)
        {
            return MapperInstance.Map<IEnumerable<User>, IEnumerable<Domain.Entities.User>>(entities);
        }

        public static User ToPersistence(Domain.Entities.User domain)
        {
            return MapperInstance.Map<Domain.Entities.User, User>(domain);
        }

        #endregion
    }
}