using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class Expense : BaseDomainEventHandler<int>
    {
        public int TransactionId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }

        public Expense()
        {
            // For Mapping
        }

        public Expense(
            int id,
            int transactionId,
            DateTime date,
            decimal amount,
            decimal rate,
            DateTime createdOn,
            DateTime updatedOn)
        {
            Id = id;
            TransactionId = transactionId;
            Date = date;
            Amount = amount;
            Rate = rate;
            Value = amount / rate;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }

        public Expense UpdateDate(DateTime? date)
        {
            return UpdateProperty<Expense>(date, Date, x => Date = x);
        }

        public Expense UpdateAmount(decimal? amount)
        {
            if (amount != null && amount <= 0)
            {
                //TODO:
            }

            return UpdateProperty<Expense>(amount, Amount, x => Amount = x, () => Value = Amount / Rate);
        }

        public Expense UpdateRate(decimal? rate)
        {
            if (rate != null && rate <= 0)
            {
                //TODO:
            }

            return UpdateProperty<Expense>(rate, Rate, x => Rate = x, () => Value = Amount / Rate);
        }

        protected override IEvent GetEvent()
        {
            return null;
        }
    }
}