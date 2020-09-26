using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BudgetManagement.Shared.Server.Api
{
    /// <summary>
    /// Defines custom Json serialization.
    /// </summary>
    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.Formatting = Formatting.Indented;
        }
    }
}