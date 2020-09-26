namespace BudgetManagement.Api.Configuration
{
    public interface IConfigManager
    {
        string GetAppSetting(string key);
        int GetIntAppSetting(string key);
        string GetConnectionString(string name);
    }
}