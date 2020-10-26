using BudgetManagement.Domain.Entities.Base;

namespace BudgetManagement.Domain.Entities
{
    public class User : BaseDomain<int>
    {
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public bool Active { get; private set; }

        public User()
        {
            // For Mapping
        }

        public User(
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