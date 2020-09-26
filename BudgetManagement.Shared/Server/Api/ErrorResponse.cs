using System;
using Nancy.Configuration;
using Nancy.Responses;
using Nancy.Serialization.JsonNet;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace BudgetManagement.Shared.Server.Api
{
    /// <summary>
    /// Creates an error response for return from an API. The framework provides standard, 
    /// predefined error responses for the most common situations, but developers can use this class
    /// to create and return custom errors from their API. The framework will handle serializing the
    /// error into consistent, well-defined format.
    /// </summary>
    public class ErrorResponse : JsonResponse<Error>
    {
        public ErrorResponse(Error error, INancyEnvironment env,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(error, new JsonNetSerializer(new CustomJsonSerializer()), env)
        {
            // TODO: this might fail if the status code enums are not identical
            StatusCode = (Nancy.HttpStatusCode)Enum.Parse(typeof(Nancy.HttpStatusCode), statusCode.ToString());
        }

        public ErrorResponse(Error error, ApiModule module,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : this(error, module.Context.Environment, statusCode)
        {
        }
    }
}