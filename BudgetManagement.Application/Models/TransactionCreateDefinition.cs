using System;
using System.Collections.Generic;

namespace BudgetManagement.Application.Models
{
    public class TransactionCreateDefinition
    {
        public int BudgetId { get; set; }
        public int? TransactionTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public IReadOnlyCollection<ExpenseCreateDefinition> Expenses { get; set; }
        public IReadOnlyCollection<IncomeCreateDefinition> Incomes { get; set; }
    }
}