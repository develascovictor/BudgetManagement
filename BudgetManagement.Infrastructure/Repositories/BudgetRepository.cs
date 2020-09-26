using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Infrastructure.Whitelists;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class BudgetRepository : BaseRepository<Budget, Domain.Entities.Budget>, IBudgetRepository
    {
        public BudgetRepository(IBudgetManagementContext context)
            : base(context, new BudgetWhitelist())
        {
        }

        protected override IQueryable<Budget> Query =>
            Context.Budgets
            .Where(npr => npr.Active);

        protected override Domain.Entities.Budget ToDomain(Budget entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.Budget> ToDomain(IEnumerable<Budget> entities) => EntityMapper.ToDomain(entities);

        protected override Budget ToPersistence(Domain.Entities.Budget domain) => EntityMapper.ToPersistence(domain);
    }
}