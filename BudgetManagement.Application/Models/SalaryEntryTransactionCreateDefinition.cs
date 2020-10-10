using BudgetManagement.Application.Models.Base;

namespace BudgetManagement.Application.Models
{
    public class SalaryEntryTransactionCreateDefinition : BaseTransactionDefinition
    {
        public int SalaryEntryId { get; set; }
        public int BudgetId { get; set; }
    }
}