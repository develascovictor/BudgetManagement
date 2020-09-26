using BudgetManagement.Infrastructure.Whitelists.Interfaces;
using BudgetManagement.Persistence.SqlServer;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Infrastructure.Whitelists
{
    public class BudgetWhitelist : IWhitelist
    {
        public IReadOnlyDictionary<string, string> Whitelist => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"name", nameof(Budget.Name)}
        };
    }
}