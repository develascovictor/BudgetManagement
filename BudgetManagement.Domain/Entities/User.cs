using BudgetManagement.Domain.Entities.Base;

namespace BudgetManagement.Domain.Entities
{
    public class User : BaseDomain<int>
    {
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public User()
        {
            // For Mapping
        }

        public User(
            int id,
            string name,
            string userName,
            string password,
            bool active)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
            Active = active;
        }
    }
}