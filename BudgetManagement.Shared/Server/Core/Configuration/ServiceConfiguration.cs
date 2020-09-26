using System.Configuration;

namespace BudgetManagement.Shared.Server.Core.Configuration
{
    public class ServiceConfiguration
    {
        public ServiceConfiguration(string configurationSection)
        {
            var config = (ServiceSection)ConfigurationManager.GetSection(configurationSection);

            if (config == null)
            {
                throw new ConfigurationErrorsException(string.Format("The section '{0}' does not exist in your configuration file.", configurationSection));
            }

            SetConfigurationInstanceValues(config);
        }

        private void SetConfigurationInstanceValues(ServiceSection config)
        {
            Enabled = config.Enabled.Value;
            Environment = config.Environment.Value;
            TerminateOnRegistrationFailure = config.TerminateOnRegistrationFailure.Value;
            ApiSettings = new ApiSettings(config.Api.Enabled);
            DisableRegistration = config.DisableRegistration.Value;
        }

        public ServiceConfiguration(ServiceConfiguration serviceConfiguration)
        {
            var configSection = new ServiceSection
            {
                Enabled = { Value = serviceConfiguration.Enabled },
                TerminateOnRegistrationFailure = { Value = serviceConfiguration.TerminateOnRegistrationFailure },
                Environment = { Value = serviceConfiguration.Environment },
                Api = new ServiceSection.ApiElement()
                {
                    Enabled = serviceConfiguration.ApiSettings.Enabled
                },
                DisableRegistration = { Value = serviceConfiguration.DisableRegistration }
            };

            SetConfigurationInstanceValues(configSection);
        }

        public bool Enabled { get; set; }
        public bool TerminateOnRegistrationFailure { get; set; }
        public string Environment { get; set; }
        public ApiSettings ApiSettings { get; set; }
        public bool DisableRegistration { get; set; }
    }

    public class ApiSettings
    {
        public ApiSettings(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { get; set; }
    }
}
