using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using Expressions;
using System.Collections.Generic;
using System.Linq;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class TransactionTypeRepository : BaseRepository<TransactionType, Domain.Entities.TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(IBudgetManagementContext context)
            : base(context)
        {
        }

        protected override IQueryable<TransactionType> Query =>
            Context.TransactionTypes;

        protected override Domain.Entities.TransactionType ToDomain(TransactionType entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.TransactionType> ToDomain(IEnumerable<TransactionType> entities) => EntityMapper.ToDomain(entities);

        protected override TransactionType ToPersistence(Domain.Entities.TransactionType domain) => EntityMapper.ToPersistence(domain);

        public IEnumerable<Domain.Entities.TransactionType> GetByBudgetId(int budgetId)
        {
            var expression = ExpressionExtensions.CreateEqualExpression<TransactionType, int>(nameof(TransactionType.BudgetId), budgetId, "tp");
            return Get(expression);
        }
    }
}