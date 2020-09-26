using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class SalaryEntry : BaseDomainEventHandler<int>
    {
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; }

        public SalaryEntry()
        {
            // For Mapping
        }

        public SalaryEntry(
            int id,
            int userId,
            DateTime date,
            decimal amount,
            decimal rate,
            DateTime createdOn,
            DateTime updatedOn)
        {
            Id = id;
            UserId = userId;
            Date = date.Date;
            Amount = amount;
            Rate = rate;
            Value = amount / rate;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }

        protected override IEvent GetEvent()
        {
            return null;
        }
    }
}