using Newtonsoft.Json;
using System;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Models
{
    public class SalaryIncomeDto
    {
        public int Id { get; private set; }
        public int TransactionId { get; private set; }
        public int? SalaryEntryId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }
        public string TransactionDescription { get; private set; }
        public int BudgetId { get; private set; }
        public string BudgetName { get; private set; }

        public SalaryIncomeDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public SalaryIncomeDto(
            int id,
            int transactionId,
            int? salaryEntryId,
            DateTime date,
            decimal amount,
            decimal rate,
            decimal value,
            string transactionDescription,
            int budgetId,
            string budgetName)
        {
            Id = id;
            TransactionId = transactionId;
            SalaryEntryId = salaryEntryId;
            Date = date;
            Amount = amount;
            Rate = rate;
            Value = value;
            TransactionDescription = transactionDescription;
            BudgetId = budgetId;
            BudgetName = budgetName;
        }
    }
}