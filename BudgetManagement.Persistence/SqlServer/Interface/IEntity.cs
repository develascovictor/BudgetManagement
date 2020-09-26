using System;

namespace BudgetManagement.Persistence.SqlServer.Interface
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}