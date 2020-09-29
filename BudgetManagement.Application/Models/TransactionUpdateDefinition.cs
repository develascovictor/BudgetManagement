using System;

namespace BudgetManagement.Application.Models
{
    public class TransactionUpdateDefinition
    {
        public int? TransactionTypeId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}