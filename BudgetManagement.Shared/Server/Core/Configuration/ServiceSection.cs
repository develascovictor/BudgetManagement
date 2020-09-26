using System.Configuration;

namespace BudgetManagement.Shared.Server.Core.Configuration
{
    public class ServiceSection : ConfigurationSection
    {
        public ServiceSection()
        {
            // HACK: this is a workaround to get the IsRequired attribute to be honored (for all configuration
            // elements on which it is defined, not just the one referenced in this line of code)
            // See http://stackoverflow.com/questions/4091693/c-sharp-configurationsection-isrequired-attribute

            if (Enabled.ElementInformation.IsPresent)
            {

            }
        }

        [ConfigurationProperty("enabled", IsRequired = true)]
        public EnabledElement Enabled
        {
            get => (EnabledElement)this["enabled"];
            set => this["enabled"] = value;
        }

        public class EnabledElement : ConfigurationElement
        {
            [ConfigurationProperty("value", DefaultValue = false, IsRequired = true)]
            public bool Value
            {
                get => (bool)this["value"];
                set => this["value"] = value;
            }
        }

        [ConfigurationProperty("terminateOnRegistrationFailure", IsRequired = false)]
        public TerminateOnRegistrationFailureElement TerminateOnRegistrationFailure
        {
            get => (TerminateOnRegistrationFailureElement)this["terminateOnRegistrationFailure"];
            set => this["terminateOnRegistrationFailure"] = value;
        }

        public class TerminateOnRegistrationFailureElement : ConfigurationElement
        {
            [ConfigurationProperty("value", DefaultValue = true, IsRequired = true)]
            public bool Value
            {
                get => (bool)this["value"];
                set => this["value"] = value;
            }
        }

        [ConfigurationProperty("api", IsRequired = false)]
        public ApiElement Api
        {
            get => (ApiElement)this["api"];
            set => this["api"] = value;
        }

        public class ApiElement : ConfigurationElement
        {
            [ConfigurationProperty("enabled", DefaultValue = false, IsRequired = true)]
            public bool Enabled
            {
                get => (bool)this["enabled"];
                set => this["enabled"] = value;
            }
        }

        [ConfigurationProperty("environment", IsRequired = true)]
        public EnvironmentElement Environment
        {
            get => (EnvironmentElement)this["environment"];
            set => this["environment"] = value;
        }

        public class EnvironmentElement : ConfigurationElement
        {
            [ConfigurationProperty("value", DefaultValue = "", IsRequired = true)]
            public string Value
            {
                get => (string)this["value"];
                set => this["value"] = value;
            }
        }

        [ConfigurationProperty("disableRegistration", IsRequired = false)]
        public DisableRegistrationElement DisableRegistration
        {
            get => (DisableRegistrationElement)this["disableRegistration"];
            set => this["disableRegistration"] = value;
        }

        public class DisableRegistrationElement : ConfigurationElement
        {
            [ConfigurationProperty("value", DefaultValue = false, IsRequired = true)]
            public bool Value
            {
                get => (bool)this["value"];
                set => this["value"] = value;
            }
        }
    }
}