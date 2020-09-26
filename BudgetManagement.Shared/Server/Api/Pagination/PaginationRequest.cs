namespace BudgetManagement.Shared.Server.Api.Pagination
{
    /// <summary>
    /// Represent cursor-based pagination information.
    /// </summary>
    public class PaginationRequest
    {
        /// <summary>
        /// The system default for the pagination limit in a request.
        /// </summary>
        public static readonly int DefaultLimit = 1000;
        /// <summary>
        /// The system default for the cursor value in a request.
        /// </summary>
        public static readonly string DefaultCursor = null;

        /// <summary>
        /// The value of a cursor indicating a location in a collection of resources.
        /// </summary>
        public string Cursor { get; set; }
        /// <summary>
        /// A value indicating the number of items to return from a collection of resources.
        /// </summary>
        public int Limit { get; set; }
    }
}