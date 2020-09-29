using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.Event;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Domain.Entities
{
    public class Transaction : BaseDomainEventHandler<int>
    {
        public int BudgetId { get; private set; }
        public int? TransactionTypeId { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }
        public List<Expense> Expenses { get; private set; }
        public List<Income> Incomes { get; private set; }

        public Transaction()
        {
            // For Mapping
        }

        public Transaction(
            int id,
            int budgetId,
            int? transactionTypeId,
            DateTime date,
            string description,
            string notes,
            DateTime createdOn,
            DateTime updatedOn,
            List<Expense> expenses = null,
            List<Income> incomes = null)
        {
            Id = id;
            BudgetId = budgetId;
            TransactionTypeId = transactionTypeId;
            Date = date.Date;
            Description = description;
            Notes = notes;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;

            Expenses = expenses ?? new List<Expense>();
            Incomes = incomes ?? new List<Income>();
        }

        protected override IEvent GetEvent()
        {
            return null;
        }

        public Transaction UpdateTransactionTypeId(int? transactionTypeId)
        {
            return UpdateProperty<Transaction>(transactionTypeId, TransactionTypeId, x => TransactionTypeId = x);
        }

        public Transaction UpdateDate(DateTime? date)
        {
            return UpdateProperty<Transaction>(date, Date, x => Date = x);
        }

        public Transaction UpdateDescription(string description)
        {
            return UpdateProperty<Transaction>(description, Description, x => Description = x);
        }

        public Transaction UpdateNotes(string notes)
        {
            return UpdateProperty<Transaction>(notes, Notes, x => Notes = x);
        }
    }
}