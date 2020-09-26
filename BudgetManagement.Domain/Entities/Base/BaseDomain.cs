namespace BudgetManagement.Domain.Entities.Base
{
    public abstract class BaseDomain<TId>
    {
        public TId Id { get; protected set; }
    }
}