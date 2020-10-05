namespace BudgetManagement.Domain.Exceptions
{
    public class ExpenseNotFoundException : DomainException
    {
        public override string ErrorCode => "ENF_DEX";

        public ExpenseNotFoundException(int id)
            : base($"Expense not found [ID: {id}].")
        {
        }
    }
}