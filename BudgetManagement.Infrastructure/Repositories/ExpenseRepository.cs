using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense, Domain.Entities.Expense>, IExpenseRepository
    {
        public ExpenseRepository(IBudgetManagementContext context)
            : base(context)
        {
        }

        protected override IQueryable<Expense> Query =>
            Context.Expenses;

        protected override Domain.Entities.Expense ToDomain(Expense entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.Expense> ToDomain(IEnumerable<Expense> entities) => EntityMapper.ToDomain(entities);

        protected override Expense ToPersistence(Domain.Entities.Expense domain) => EntityMapper.ToPersistence(domain);

        protected override void UpdateFields(Expense entity, Domain.Entities.Expense domain)
        {
            entity.Date = domain.Date;
            entity.Amount = domain.Amount;
            entity.Rate = domain.Rate;
            entity.Value = domain.Value;
            entity.UpdatedOn = domain.UpdatedOn;
        }
    }
}