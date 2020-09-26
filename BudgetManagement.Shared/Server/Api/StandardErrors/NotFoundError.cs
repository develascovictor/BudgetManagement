using System.Net;

namespace BudgetManagement.Shared.Server.Api.StandardErrors
{
    /// <summary>
    /// Indicates that the resource requested by the API consumer could not be found.
    /// </summary>
    public static class NotFoundError
    {
        private static readonly string Code = ErrorConstants.NotFoundErrorCode;
        private static readonly string Url = string.Format(ErrorConstants.InfoUrlTemplateString, Code);

        static NotFoundError()
        {
            Error = new Error()
            {
                ErrorCode = Code,
                Message = "The server could not find the resource specified in the request.",
                Detail = "Verify that the requested resource type exists and that the resource id supplied in the request is valid.",
                InfoUrl = Url
            };
        }

        public static Error Error { get; private set; }

        public static HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.NotFound; }
        }
    }
}