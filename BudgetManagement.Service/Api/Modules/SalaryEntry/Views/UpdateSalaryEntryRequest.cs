using System;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Views
{
    public class UpdateSalaryEntryRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
    }
}