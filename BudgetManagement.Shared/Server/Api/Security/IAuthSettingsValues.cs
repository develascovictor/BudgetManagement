namespace BudgetManagement.Shared.Server.Api.Security
{
    /// <summary>
    /// Defines authentication and authorization settings in the service API framework.
    /// </summary>
    public interface IAuthSettingsValues
    {
        string SchemeName { get; }
    }
}