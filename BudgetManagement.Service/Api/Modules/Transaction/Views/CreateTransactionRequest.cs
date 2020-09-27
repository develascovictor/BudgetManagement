using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.Transaction.Views
{
    public class CreateTransactionRequest
    {
        public int BudgetId { get; set; }
        public int? TransactionTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public IReadOnlyCollection<CreateExpenseRequest> Expenses { get; set; }
        public IReadOnlyCollection<CreateIncomeRequest> Incomes { get; set; }
    }
}