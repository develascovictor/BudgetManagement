using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class Budget : BaseDomainEventHandler<int>
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public bool HasTypes { get; private set; }
        public bool Active { get; private set; }

        public Budget()
        {
            // For Mapping
        }

        public Budget(
            int id,
            int userId,
            string name,
            bool hasTypes,
            bool active,
            DateTime createdOn,
            DateTime updatedOn)
        {
            Id = id;
            UserId = userId;
            Name = name;
            HasTypes = hasTypes;
            Active = active;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }

        protected override IEvent GetEvent()
        {
            return null;
        }
    }
}