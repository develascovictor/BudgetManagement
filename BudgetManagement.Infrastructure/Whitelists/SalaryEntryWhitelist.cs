using BudgetManagement.Infrastructure.Whitelists.Interfaces;
using BudgetManagement.Persistence.SqlServer;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Infrastructure.Whitelists
{
    public class SalaryEntryWhitelist : IWhitelist
    {
        public IReadOnlyDictionary<string, string> Whitelist => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"value", nameof(SalaryEntry.Value)},
            {"date", nameof(SalaryEntry.Date)},
        };
    }
}