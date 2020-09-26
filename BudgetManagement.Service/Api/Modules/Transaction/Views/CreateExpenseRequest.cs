using System;

namespace BudgetManagement.Service.Api.Modules.Transaction.Views
{
    public class CreateExpenseRequest
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
    }
}