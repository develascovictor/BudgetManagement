using BudgetManagement.Domain.Entities.Base;
using System;

namespace BudgetManagement.Domain.Entities
{
    public class SalaryIncome : BaseDomain<int>
    {
        public int TransactionId { get; private set; }
        public int? SalaryEntryId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }
        public int BudgetId { get; private set; }
        public string BudgetName { get; private set; }

        public SalaryIncome()
        {
            // For Mapping
        }

        public SalaryIncome(
            int id,
            int transactionId,
            int? salaryEntryId,
            DateTime date,
            decimal amount,
            decimal rate,
            int budgetId,
            string budgetName)
        {
            Id = id;
            TransactionId = transactionId;
            SalaryEntryId = salaryEntryId;
            Date = date;
            Amount = amount;
            Rate = rate;
            Value = amount / rate;
            BudgetId = budgetId;
            BudgetName = budgetName;
        }
    }
}