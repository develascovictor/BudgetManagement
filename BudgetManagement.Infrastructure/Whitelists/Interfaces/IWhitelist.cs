using System.Collections.Generic;

namespace BudgetManagement.Infrastructure.Whitelists.Interfaces
{
    public interface IWhitelist
    {
        IReadOnlyDictionary<string, string> Whitelist { get; }
    }
}