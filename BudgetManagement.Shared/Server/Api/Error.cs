namespace BudgetManagement.Shared.Server.Api
{
    /// <summary>
    /// A model representing an error. Used primarily for serialization into an error
    /// for return from an API to a client.
    /// </summary>
    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string InfoUrl { get; set; }
    }
}
