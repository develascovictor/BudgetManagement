namespace BudgetManagement.Shared.Server.Api.Security
{
    /// <summary>
    /// Contains configured values for authentication and authorization setttings 
    /// used by the service API framework at runtime.
    /// </summary>
    public class AuthSettings
    {
        public AuthSettings(IAuthSettingsValues settings)
        {
            SchemeName = settings.SchemeName;
        }

        public string SchemeName { get; private set; }
    }
}