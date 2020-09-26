namespace BudgetManagement.Domain.Exceptions
{
    public class TransactionNotFoundException : DomainException
    {
        public override string ErrorCode => "TNF_DEX";

        public TransactionNotFoundException(int id)
            : base($"Transaction not found [ID: {id}].")
        {
        }
    }
}