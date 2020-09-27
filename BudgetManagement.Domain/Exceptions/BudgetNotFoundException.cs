namespace BudgetManagement.Domain.Exceptions
{
    public class BudgetNotFoundException : DomainException
    {
        public override string ErrorCode => "BNF_DEX";

        public BudgetNotFoundException(int id)
            : base($"Budget not found [ID: {id}].")
        {
        }
    }
}