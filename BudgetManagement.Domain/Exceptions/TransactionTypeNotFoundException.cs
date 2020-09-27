namespace BudgetManagement.Domain.Exceptions
{
    public class TransactionTypeNotFoundException : DomainException
    {
        public override string ErrorCode => "TTNF_DEX";

        public TransactionTypeNotFoundException(int id)
            : base($"Transaction Type not found [ID: {id}].")
        {
        }
    }
}