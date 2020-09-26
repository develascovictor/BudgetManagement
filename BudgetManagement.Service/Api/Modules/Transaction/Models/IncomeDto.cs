using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.Transaction.Models
{
    public class IncomeDto
    {
        public int Id { get; private set; }
        public int TransactionId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }
        public IDictionary<string, string> Errors { get; private set; }

        public IncomeDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public IncomeDto(
            int id,
            int transactionId,
            DateTime date,
            decimal amount,
            decimal rate,
            decimal value,
            IDictionary<string, string> errors = null)
        {
            Id = id;
            TransactionId = transactionId;
            Date = date;
            Amount = amount;
            Rate = rate;
            Value = value;

            Errors = errors;
        }
    }
}