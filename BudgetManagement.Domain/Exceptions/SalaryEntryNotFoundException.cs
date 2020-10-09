namespace BudgetManagement.Domain.Exceptions
{
    public class SalaryEntryNotFoundException : DomainException
    {
        public override string ErrorCode => "SENF_DEX";

        public SalaryEntryNotFoundException(int id)
            : base($"Salary Entry not found [ID: {id}].")
        {
        }
    }
}