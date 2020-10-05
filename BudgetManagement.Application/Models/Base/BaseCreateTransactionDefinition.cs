using System;

namespace BudgetManagement.Application.Models.Base
{
    public abstract class BaseCreateTransactionDefinition : BaseTransactionDefinition
    {
        public int TransactionId { get; set; }
    }
}