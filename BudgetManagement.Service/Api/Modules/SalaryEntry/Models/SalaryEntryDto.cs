using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Models
{
    public class SalaryEntryDto
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal Value { get; private set; }
        public List<SalaryIncomeDto> Incomes { get; private set; }
        public IDictionary<string, string> Errors { get; private set; }

        public SalaryEntryDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public SalaryEntryDto(
            int id,
            int userId,
            DateTime date,
            decimal amount,
            decimal rate,
            decimal value,
            List<SalaryIncomeDto> incomes = null,
            IDictionary<string, string> errors = null)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Amount = amount;
            Rate = rate;
            Value = value;

            Incomes = incomes ?? new List<SalaryIncomeDto>();
            Errors = errors;
        }
    }
}