using Newtonsoft.Json;

namespace BudgetManagement.Service.Api.Modules.User.Models
{
    public class UserDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public UserDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public UserDto(
            int id,
            string name,
            bool active)
        {
            Id = id;
            Name = name;;
            Active = active;
        }
    }
}