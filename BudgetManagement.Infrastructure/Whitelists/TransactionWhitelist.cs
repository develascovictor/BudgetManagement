using BudgetManagement.Infrastructure.Whitelists.Interfaces;
using BudgetManagement.Persistence.SqlServer;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Infrastructure.Whitelists
{
    public class TransactionWhitelist : IWhitelist
    {
        public IReadOnlyDictionary<string, string> Whitelist => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //{"budgetId", nameof(Transaction.BudgetId)},
            {"transactionTypeId", nameof(Transaction.TransactionTypeId)},
            {"date", nameof(Transaction.Date)},
            {"description", nameof(Transaction.Description)},
            {"notes", nameof(Transaction.Notes)}
        };
    }
}