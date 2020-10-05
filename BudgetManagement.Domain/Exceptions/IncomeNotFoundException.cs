namespace BudgetManagement.Domain.Exceptions
{
    public class IncomeNotFoundException : DomainException
    {
        public override string ErrorCode => "INF_DEX";

        public IncomeNotFoundException(int id)
            : base($"Income not found [ID: {id}].")
        {
        }
    }
}