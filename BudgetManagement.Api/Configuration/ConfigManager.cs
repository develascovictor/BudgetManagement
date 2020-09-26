using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace BudgetManagement.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public class ConfigManager : IConfigManager
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public int GetIntAppSetting(string key)
        {
            var value = GetAppSetting(key);
            int.TryParse(value, out var number);

            return number;
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}