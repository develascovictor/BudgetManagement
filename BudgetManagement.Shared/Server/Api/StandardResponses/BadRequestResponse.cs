using BudgetManagement.Shared.Server.Api.StandardErrors;
using Nancy;

namespace BudgetManagement.Shared.Server.Api.StandardResponses
{
    /// <summary>
    /// A response indicating that the request to the API was
    /// malformed and so could not be processed by the server. This includes errors
    /// in the format of the request body as well as 
    /// domain validation errors.
    /// </summary>
    public class BadRequestResponse : ErrorResponse
    {
        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="module">The ApiModule from which the response will be sent.</param>
        public BadRequestResponse(ApiModule module)
            : this(module, null, null, null, null) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="module">The ApiModule from which the response will be sent.</param>
        /// <param name="message">A human-readable message explaining the error.
        /// If a value of null is supplied for this parameter then a default message will be provided.</param>
        /// <param name="detail">A human-readable message that provides more detail and preferably 
        /// some indication of the action that the API consumer should take to remedy the error.
        /// If a value of null is supplied for this parameter then default details will be provided.</param>
        /// <param name="errorCode">An error code unique within the scope of an API's domain.
        /// If a value of null is supplied for this parameter then a default error code will be provided.</param>
        /// <param name="infoUrl">A url where further documentation is provided about the error.
        /// If a value of null is supplied for this parameter then a default url will be provided.</param>
        public BadRequestResponse(ApiModule module, string message, string detail,
            string errorCode, string infoUrl)
            : this(module.Context, message, detail, errorCode, infoUrl) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="context">A Nancy context from which the response will be sent.</param>
        public BadRequestResponse(NancyContext context)
            : this(context, null, null, null, null) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="context">A Nancy context from which the response will be sent.</param>
        /// <param name="message">A human-readable message explaining the error.
        /// If a value of null is supplied for this parameter then a default message will be provided.</param>
        /// <param name="detail">A human-readable message that provides more detail and preferably 
        /// some indication of the action that the API consumer should take to remedy the error.
        /// If a value of null is supplied for this parameter then default details will be provided.</param>
        /// <param name="errorCode">An error code unique within the scope of an API's domain.
        /// If a value of null is supplied for this parameter then a default error code will be provided.</param>
        /// <param name="infoUrl">A url where further documentation is provided about the error.
        /// If a value of null is supplied for this parameter then a default url will be provided.</param>
        public BadRequestResponse(NancyContext context, string message, string detail,
            string errorCode, string infoUrl)
            : base(
                new Error()
                {
                    Detail = detail ?? BadRequestError.Error.Detail,
                    ErrorCode = errorCode ?? BadRequestError.Error.ErrorCode,
                    InfoUrl = infoUrl ?? BadRequestError.Error.InfoUrl,
                    Message = message ?? BadRequestError.Error.Message
                }, context.Environment,
                BadRequestError.StatusCode)
        { }
    }
}
