using Newtonsoft.Json;

namespace BudgetManagement.Service.Api.Modules.User.Models
{
    public class UserDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }

        public UserDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public UserDto(
            int id,
            string name,
            string userName,
            bool active)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Active = active;
        }
    }
}