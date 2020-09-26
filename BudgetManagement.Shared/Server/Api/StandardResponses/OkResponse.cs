using Nancy;
using Nancy.Responses;
using Nancy.Serialization.JsonNet;

namespace BudgetManagement.Shared.Server.Api.StandardResponses
{
    /// <summary>
    /// A response indicating success. In a REST API this response is useful for indicating successful completion
    /// of a GET, PUT, or DELETE. In the case of a PUT, a representation of the updated resource should
    /// be returned.
    /// </summary>
    public class OkResponse : JsonResponse
    {
        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="module">The ApiModule from which the response will be sent.</param>
        public OkResponse(ApiModule module)
            : this(module, null) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="module">The ApiModule from which the response will be sent.</param>
        /// <param name="resource">A resource returned as a result of a request.</param>
        public OkResponse(ApiModule module, object resource)
            : this(module.Context, resource) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="context">A Nancy context from which the response will be sent.</param>
        public OkResponse(NancyContext context)
            : this(context, null) { }

        /// <summary>
        /// Creates an instance of the response.
        /// </summary>
        /// <param name="context">A Nancy context from which the response will be sent.</param>
        /// <param name="resource">A resource returned as a result of a request.</param>
        public OkResponse(NancyContext context, object resource)
            : base(resource, new JsonNetSerializer(new CustomJsonSerializer()), context.Environment)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.ReasonPhrase = "OK";
        }
    }
}