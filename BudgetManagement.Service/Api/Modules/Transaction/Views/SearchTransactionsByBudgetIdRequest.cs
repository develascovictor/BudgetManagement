using BudgetManagement.Service.Api.Modules.Base;

namespace BudgetManagement.Service.Api.Modules.Transaction.Views
{
    public class SearchTransactionsByBudgetIdRequest : BaseSearchRequest
    {
        /// <summary>
        /// Budget ID
        /// </summary>
        public int BudgetId { get; set; }
    }
}