using System;

namespace BudgetManagement.Shared.Server.Api
{
    /// <summary>
    /// Marks an ApiModule implementation as belonging to the API of a specified service type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ServiceApi : Attribute
    {
        /// <summary>
        /// The type of the service to which the attributed Api Module will be bound.
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        ///  Constructs an instance of the ServiceApi attribute class.
        /// </summary>
        /// <param name="serviceType">The service type to which the API module marked with 
        /// this attribute will be bound.</param>
        public ServiceApi(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}