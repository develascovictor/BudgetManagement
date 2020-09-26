using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class Income : BaseDomainEventHandler<int>
    {
        public int TransactionId { get; private set; }
        public int? SalaryEntryId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }

        public Income()
        {
            // For Mapping
        }

        public Income(
            int id,
            int transactionId,
            int? salaryEntryId,
            DateTime date,
            decimal amount,
            decimal rate,
            DateTime createdOn,
            DateTime updatedOn)
        {
            Id = id;
            TransactionId = transactionId;
            SalaryEntryId = salaryEntryId;
            Date = date;
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