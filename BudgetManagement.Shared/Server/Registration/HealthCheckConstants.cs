namespace BudgetManagement.Shared.Server.Registration
{
    /// <summary>
    /// Provides constants for defining health checks in an API.
    /// </summary>
    public static class HealthCheckConstants
    {
        /// <summary>
        /// The base path for health check resources. Paths to any health check resources implemented by a developer
        /// must be defined with an identifier that is unique within the scope of the service's API and that is
        /// accessible under this base resource path. For example: 
        /// string.Concat(HealthCheckConstants.BaseResourcePath, "1000") produces a valid path for a health
        /// check resource if no other health check resource within the service API has an id of 1000.
        /// </summary>
        public static readonly string BaseResourcePath = "healthchecks/";

        /// <summary>
        /// The maximum id of a range of health check resource identifiers reserved by the framework. 
        /// Values less than or equal to this value are reserved for health checks implemented by the framework. 
        /// Values above this value are available for use as identifiers of developer-defined health checks.
        /// </summary>
        public static readonly int MaxReservedId = 99;
    }
}