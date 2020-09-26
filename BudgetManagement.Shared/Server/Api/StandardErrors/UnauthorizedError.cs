using BudgetManagement.Shared.Server.Api;
using BudgetManagement.Shared.Server.Api.StandardErrors;
using System.Net;

namespace BudgetManagemet.Shared.Server.Api.StandardErrors
{
    /// <summary>
    /// Indicates that the request could not be fulfilled due to an authentication failure.
    /// Either credentials were not supplied in the request or authorization was refused for the
    /// supplied credentials.
    /// </summary>
    public static class UnauthorizedError
    {
        private static readonly string Code = ErrorConstants.UnauthorizedErrorCode;
        private static readonly string Url = string.Format(ErrorConstants.InfoUrlTemplateString, Code);

        static UnauthorizedError()
        {
            Error = new Error()
            {
                ErrorCode = Code,
                Message = "The request requires authentication.",
                Detail = "Either the specified authorization scheme is not supported, credentials were not supplied in the request, " +
                         "or authorization was refused for the supplied credentials. After verifying that the " +
                         "authorization scheme is supported, you may try submitting a new request with credentials that " +
                         "differ from those sent in the failed request.",
                InfoUrl = Url
            };
        }

        public static Error Error { get; private set; }

        public static HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.Unauthorized; }
        }
    }
}