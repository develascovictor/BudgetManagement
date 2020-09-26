using System;

namespace BudgetManagement.Application.Models
{
    public class SalaryEntryCreateDefinition
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
    }
}