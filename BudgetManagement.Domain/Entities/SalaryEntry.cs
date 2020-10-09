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
        public decimal Value { get; private set; }

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

        public SalaryEntry UpdateDate(DateTime? date)
        {
            return UpdateProperty<SalaryEntry>(date, Date, x => Date = x);
        }

        public SalaryEntry UpdateAmount(decimal? amount)
        {
            if (amount != null && amount <= 0)
            {
                //TODO:
            }

            return UpdateProperty<SalaryEntry>(amount, Amount, x => Amount = x, () => Value = Amount / Rate);
        }

        public SalaryEntry UpdateRate(decimal? rate)
        {
            if (rate != null && rate <= 0)
            {
                //TODO:
            }

            return UpdateProperty<SalaryEntry>(rate, Rate, x => Rate = x, () => Value = Amount / Rate);
        }

        protected override IEvent GetEvent()
        {
            return null;
        }
    }
}