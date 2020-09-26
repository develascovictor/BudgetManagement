using BudgetManagement.Domain.Entities.Base;

namespace BudgetManagement.Domain.Entities
{
    public class User : BaseDomain<int>
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public User()
        {
            // For Mapping
        }

        public User(
            int id,
            string name,
            bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }
    }
}