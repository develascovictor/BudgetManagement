using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class TransactionType : BaseDomainEventHandler<int>
    {
        public int BudgetId { get; private set; }
        public string Name { get; private set; }

        public TransactionType()
        {
            // For Mapping
        }

        public TransactionType(
            int id,
            int budgetId,
            string name,
            DateTime createdOn,
            DateTime updatedOn)
        {
            Id = id;
            BudgetId = budgetId;
            Name = name;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }

        protected override IEvent GetEvent()
        {
            return null;
        }
    }
}