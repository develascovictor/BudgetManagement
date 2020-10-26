using Autofac;
using BudgetManagement.Api.Configuration;
using BudgetManagement.Api.Controllers;
using BudgetManagement.Application;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Budget;
using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.TransactionType;
using BudgetManagement.Service.Api.Modules.TransactionType.Interfaces;
using BudgetManagement.Service.Api.Modules.User;
using BudgetManagement.Service.Api.Modules.User.Interfaces;

namespace BudgetManagement.Api.DependencyResolution
{
    public class DomainObjectRegister : IDomainObjectsRegister
    {
        public void RegisterDomainObjects(ContainerBuilder builder, IConfigManager configManager)
        {
            builder.RegisterType<BudgetController>();

            // Single instance registrations.
            builder.RegisterInstance<IConfigManager>(new ConfigManager());
            //builder.Register(m => ApiMapper.Map).As<IMapper>().SingleInstance();

            // respositories require request context data, so we must register with lambda and factory pattern...
            //builder.RegisterInstance(new DbContextFactory(configManager.GetConnectionString(Constants.RcatDbConnectionStringKey))).As<IDbContextFactory>();
            //builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>().InstancePerRequest();
            //builder.Register(c => c.Resolve<IRepositoryFactory>().CreateEntityRepository()).As<IEntityRepository>().InstancePerRequest();
            //builder.Register(c => c.Resolve<IRepositoryFactory>().CreateTenantRepository()).As<ITenantRepository>().InstancePerRequest();
            //builder.RegisterType<ReadOnlyTenantRepository>().As<IReadOnlyTenantRepository>().InstancePerRequest();

            builder.RegisterInstance(new BudgetManagementEntities(true)).As<IBudgetManagementContext>()
                .OnActivating(e => e.Instance.Configuration.ValidateOnSaveEnabled = false);

            // Interface layer service registrations (ALPHABETICAL)
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // Application layer service registrations (ALPHABETICAL)
            builder.RegisterType<BudgetService>().As<IBudgetService>();
            builder.RegisterType<SalaryEntryService>().As<ISalaryEntryService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();
            builder.RegisterType<TransactionTypeService>().As<ITransactionTypeService>();
            builder.RegisterType<UserService>().As<IUserService>();

            // Service layer module implementation registrations (ALPHABETICAL)
            builder.RegisterType<BudgetModuleImpl>().As<IBudgetModuleImpl>();
            builder.RegisterType<SalaryEntryModuleImpl>().As<ISalaryEntryModuleImpl>();
            builder.RegisterType<TransactionModuleImpl>().As<ITransactionModuleImpl>();
            builder.RegisterType<TransactionTypeModuleImpl>().As<ITransactionTypeModuleImpl>();
            builder.RegisterType<UserModuleImpl>().As<IUserModuleImpl>();

            // Service layer module registrations (ALPHABETICAL)
            builder.RegisterType<BudgetModule>().As<IBudgetModule>();
            builder.RegisterType<SalaryEntryModule>().As<ISalaryEntryModule>();
            builder.RegisterType<TransactionModule>().As<ITransactionModule>();
            builder.RegisterType<TransactionTypeModule>().As<ITransactionTypeModule>();
            builder.RegisterType<UserModule>().As<IUserModule>();
        }
    }
}