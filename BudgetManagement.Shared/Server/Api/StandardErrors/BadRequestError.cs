using System.Net;

namespace BudgetManagement.Shared.Server.Api.StandardErrors
{
    /// <summary>
    /// Indicates that the request is malformed and could not be understood by the server.
    /// </summary>
    public static class BadRequestError
    {
        private static readonly string Code = ErrorConstants.BadRequestErrorCode;
        private static readonly string Url = string.Format(ErrorConstants.InfoUrlTemplateString, Code);

        static BadRequestError()
        {
            Error = new Error()
            {
                ErrorCode = Code,
                Message = "The request could not be understood due to malformed syntax.",
                Detail = "Verify that the request is valid and that any data " +
                         "supplied in the body of the request conforms to the specifications " +
                         "of the API.",
                InfoUrl = Url
            };
        }

        public static Error Error { get; private set; }

        public static HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.BadRequest; }
        }
    }
}