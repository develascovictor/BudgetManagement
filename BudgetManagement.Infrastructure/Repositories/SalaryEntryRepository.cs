using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Infrastructure.Whitelists;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class SalaryEntryRepository : BaseRepository<SalaryEntry, Domain.Entities.SalaryEntry>, ISalaryEntryRepository
    {
        public SalaryEntryRepository(IBudgetManagementContext context)
            : base(context, new SalaryEntryWhitelist())
        {
        }

        protected override IQueryable<SalaryEntry> Query =>
            Context.SalaryEntries;

        protected override Domain.Entities.SalaryEntry ToDomain(SalaryEntry entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.SalaryEntry> ToDomain(IEnumerable<SalaryEntry> entities) => EntityMapper.ToDomain(entities);

        protected override SalaryEntry ToPersistence(Domain.Entities.SalaryEntry domain) => EntityMapper.ToPersistence(domain);

        protected override void UpdateFields(SalaryEntry entity, Domain.Entities.SalaryEntry domain)
        {
            entity.Date = domain.Date;
            entity.Amount = domain.Amount;
            entity.Rate = domain.Rate;
            entity.Value = domain.Value;
            entity.UpdatedOn = domain.UpdatedOn;
        }
    }
}