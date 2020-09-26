namespace BudgetManagement.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public override string ErrorCode => "UNF_DEX";

        public UserNotFoundException(int id)
            : base($"User not found [ID: {id}].")
        {
        }
    }
}