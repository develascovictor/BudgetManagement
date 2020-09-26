using System;

namespace BudgetManagement.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public virtual string ErrorCode => "DEX";

        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}