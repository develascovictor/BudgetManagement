using System;

namespace BudgetManagement.Service.Api.Modules.Transaction.Views
{
    public class UpdateTransactionRequest
    {
        public int Id { get; set; }
        public int? TransactionTypeId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}