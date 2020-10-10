using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.Transaction.Views
{
    public class CreateSalaryEntryTransactionRequest
    {
        public int SalaryEntryId { get; set; }
        public int BudgetId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
    }
}