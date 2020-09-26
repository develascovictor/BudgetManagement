using System;

namespace BudgetManagement.Domain.Exceptions
{
    public class DomainTypeMismatchException : DomainException
    {
        public override string ErrorCode => "DTM_DEX";

        public DomainTypeMismatchException(Type genericClassType, Type baseDomainClassType)
            : base($"Generic class type '{genericClassType}' must be equal to BaseDomain class type '{baseDomainClassType}'.")
        {
        }
    }
}