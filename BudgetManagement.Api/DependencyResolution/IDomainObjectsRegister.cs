using Autofac;
using BudgetManagement.Api.Configuration;

namespace BudgetManagement.Api.DependencyResolution
{
    public interface IDomainObjectsRegister
    {
        void RegisterDomainObjects(ContainerBuilder builder, IConfigManager configManager);
    }
}