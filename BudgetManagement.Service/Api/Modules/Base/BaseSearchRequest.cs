namespace BudgetManagement.Service.Api.Modules.Base
{
    public abstract class BaseSearchRequest
    {
        /// <summary>
        /// Filter string
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Sort string
        /// </summary>
        public string Sort { get; set; }
    }
}