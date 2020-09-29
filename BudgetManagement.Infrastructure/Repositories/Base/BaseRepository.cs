using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Infrastructure.Whitelists.Interfaces;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Interface;
using Expressions;
using Filtering.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BudgetManagement.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TDomain>
        where TEntity : class, IEntity<int>
        where TDomain : BaseDomain<int>
    {
        protected readonly IBudgetManagementContext Context;
        protected readonly IWhitelist Whitelist;

        public BaseRepository(IBudgetManagementContext context)
        {
            Context = context;
        }

        public BaseRepository(IBudgetManagementContext context, IWhitelist whitelist)
        {
            Context = context;
            Whitelist = whitelist;
        }

        protected abstract IQueryable<TEntity> Query { get; }

        protected abstract TDomain ToDomain(TEntity entity);

        protected abstract IEnumerable<TDomain> ToDomain(IEnumerable<TEntity> entities);

        protected abstract TEntity ToPersistence(TDomain domain);

        protected virtual void UpdateFields(TEntity entity, TDomain domain)
        {

        }

        public IEnumerable<TDomain> Search(string filterOptions, string sortOptions, int index, int limit, out long total)
        {
            return Search(x => true, filterOptions, sortOptions, index, limit, out total);
        }

        public TDomain GetById(int id)
        {
            var entity = Query.FirstOrDefault(x => x.Id == id);
            return ToDomain(entity);
        }

        public TDomain Create(TDomain domain)
        {
            var entity = ToPersistence(domain);
            entity = Context.Set<TEntity>().Add(entity);

            Context.SaveChanges();

            return ToDomain(entity);
        }

        public TDomain Update(TDomain domain)
        {
            var entity = Query.FirstOrDefault(x => x.Id == domain.Id);

            if (entity == null)
            {
                return null;
            }

            UpdateFields(entity, domain);
            Context.SaveChanges();

            return ToDomain(entity);
        }

        protected IEnumerable<TDomain> Search(Expression<Func<TEntity, bool>> baseExpression, string filterOptions, string sortOptions, int index, int limit, out long total)
        {
            var filterExpression = FilterOptionExtensions.GetFilterExpression<TEntity>(filterOptions, Whitelist?.Whitelist);
            var finalExpression = baseExpression.And(filterExpression);
            var query = Query.Where(finalExpression);

            total = query.LongCount();

            if (total == 0)
            {
                return Enumerable.Empty<TDomain>();
            }

            var sortDictionary = SortOptionExtensions.BuildSortByExpression<TEntity>(sortOptions);
            var entities = query.ApplySortByExpressions(sortDictionary).Skip(index).Take(limit).ToList();

            return ToDomain(entities);
        }

        protected IEnumerable<TDomain> Get(Expression<Func<TEntity, bool>> expression = null)
        {
            expression = expression ?? (x => true);
            var entities = Query.Where(expression).ToList();

            return ToDomain(entities);
        }
    }
}