using System;
using BudgetManagement.Domain.Repositories;
using BudgetManagement.Infrastructure.Repositories.Base;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Persistence.SqlServer.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expressions;

namespace BudgetManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, Domain.Entities.User>, IUserRepository
    {
        public UserRepository(IBudgetManagementContext context)
            : base(context)
        {
        }

        protected override IQueryable<User> Query =>
            Context.Users.Where(x => x.Active);

        protected override Domain.Entities.User ToDomain(User entity) => EntityMapper.ToDomain(entity);

        protected override IEnumerable<Domain.Entities.User> ToDomain(IEnumerable<User> entities) => EntityMapper.ToDomain(entities);

        protected override User ToPersistence(Domain.Entities.User domain) => EntityMapper.ToPersistence(domain);

        public Domain.Entities.User Login(string userName, string password)
        {
            var expression = ((Expression<Func<User, bool>>) (user => user.UserName == userName && user.Password == password && user.Active));
            return Get(expression);
        }
    }
}