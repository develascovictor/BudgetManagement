using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Infrastructure.Whitelists;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction, Domain.Entities.Transaction>, ITransactionRepository
    {
        public TransactionRepository(IBudgetManagementContext context)
            : base(context, new TransactionWhitelist())
        {
        }

        protected override IQueryable<Transaction> Query =>
            Context.Transactions
            .Include(x => x.Expenses)
            .Include(x => x.Incomes);

        protected override Domain.Entities.Transaction ToDomain(Transaction entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.Transaction> ToDomain(IEnumerable<Transaction> entities) => EntityMapper.ToDomain(entities);

        protected override Transaction ToPersistence(Domain.Entities.Transaction domain) => EntityMapper.ToPersistence(domain);

        protected override void UpdateFields(Transaction entity, Domain.Entities.Transaction domain)
        {
            entity.TransactionTypeId = domain.TransactionTypeId;
            entity.Date = domain.Date;
            entity.Description = domain.Description;
            entity.Notes = domain.Notes;
            entity.UpdatedOn = domain.UpdatedOn;
        }

        public IEnumerable<Domain.Entities.Transaction> SearchByBudgetId(int budgetId, string filterOptions, string sortOptions, int index, int limit, out long total)
        {
            var expression = ExpressionExtensions.CreateEqualExpression<Transaction, int>(nameof(Transaction.BudgetId), budgetId, "tra");
            return Search(expression, filterOptions, sortOptions, index, limit, out total);
        }
    }
}