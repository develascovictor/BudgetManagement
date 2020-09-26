using System.Net;

namespace BudgetManagement.Shared.Server.Api.StandardErrors
{
    /// <summary>
    /// Indicates that an unexpected error occurred on the server.
    /// </summary>
    public static class InternalServerError
    {
        private static readonly string Code = ErrorConstants.InternalServerErrorErrorCode;
        private static readonly string Url = string.Format(ErrorConstants.InfoUrlTemplateString, Code);

        static InternalServerError()
        {
            Error = new Error()
            {
                ErrorCode = Code,
                Message = "The server encountered an unexpected condition which prevented it from fulfilling the request.",
                Detail = "Retry the request (exponential backoff is a recommended strategy) or contact Cisco Impact.",
                InfoUrl = Url
            };
        }

        public static Error Error { get; private set; }

        public static HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.InternalServerError; }
        }
    }
}