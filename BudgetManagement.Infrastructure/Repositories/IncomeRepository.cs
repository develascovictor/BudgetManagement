using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class IncomeRepository : BaseRepository<Income, Domain.Entities.Income>, IIncomeRepository
    {
        public IncomeRepository(IBudgetManagementContext context)
            : base(context)
        {
        }

        protected override IQueryable<Income> Query =>
            Context.Incomes;

        protected override Domain.Entities.Income ToDomain(Income entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.Income> ToDomain(IEnumerable<Income> entities) => EntityMapper.ToDomain(entities);

        protected override Income ToPersistence(Domain.Entities.Income domain) => EntityMapper.ToPersistence(domain);
    }
}