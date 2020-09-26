using BudgetManagement.Shared.Server.Api.Security;
using BudgetManagement.Shared.Server.Api.StandardResponses;
using log4net;
using Nancy;
using Nancy.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BudgetManagement.Shared.Server.Api
{
    /// <summary>
    /// Base class for defining an API that will be bound to a service. More than one API module
    /// can exist for a given service. The collection of all API modules for a service defines
    /// the scope of the API for that service. Separate API modules are useful for defining separate
    /// resources in a single service's API. For example, one API module might define the paths for
    /// accessing the "widgets" resource (e.g. "/widgets") while another might define the paths for 
    /// the "sprockets" resource (e.g. "/sprockets"), where both are resources on the same service.
    /// </summary>
    public class ApiModule : NancyModule
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const string ReceivedApiRequestMessage = "Received an API request. Client address: [{0}], Request: [{1} {2}], " +
            "Request Id: [{3}].";
        private const string ReceivedApiRequestBodyMessage = "Request Body: [{0}], Request Id: [{1}].";

        private const string ReplacedInvalidRequestIdMessage = "The received request Id [{0}] is not a valid UUID and has been " +
            "replaced with request Id [{1}].";
        private const string WwwAuthenticateHeaderName = "WWW-Authenticate";

        private const string ReturningApiResponseMessage =
            "Returning an API response. Response Code: [{0}], Request Id: [{1}].";
        private const string ReturningApiResponseBodyMessage =
            "Response Body: [{0}], Request Id: [{1}].";

        private const string ErrorEvaluatingBodyMessage =
            "An exception occured while attempting to evaluate the response body. " +
            "Message: [{0}], Request Id: [{1}].";

        private const string NullString = "null";

        /// <summary>
        /// Creates an instance of the API module. Base functionality and hooks are defined here.
        /// </summary>
        public ApiModule()
        {
            Before += AddToBefore;
            After += AddToAfter;
        }

        private Func<NancyContext, Response> AddToBefore => ctx =>
        {
            //if (ctx.Request.Url.ToString().Contains(HealthCheckConstants.BaseResourcePath))
            //{
            //    Log.DebugFormat(ReceivedHealthCheckApiRequestMessage, ctx.Request.Url);
            //    return null;
            //}

            if (ctx.Request.Url.Path.Contains("healthcheck"))
            {
                return null;
            }

            string requestId;

            var requestIdHeader = ctx.Request.Headers[Constants.Request.IdHeaderName];
            var requestIdHeaderList = requestIdHeader as IList<string> ?? requestIdHeader.ToList();

            if (requestIdHeaderList.Any() && !string.IsNullOrEmpty(requestIdHeaderList.First()))
            {
                var inputRequestId = requestIdHeaderList.First();

                try
                {
                    requestId = new Guid(inputRequestId).ToString();
                }

                catch (Exception)
                {
                    requestId = Guid.NewGuid().ToString();
                    Log.WarnFormat(ReplacedInvalidRequestIdMessage, inputRequestId, requestId);
                }
            }

            else
            {
                requestId = Guid.NewGuid().ToString();
            }

            ctx.Items.Add(Constants.Request.IdKeyName, requestId);

            string body = null;

            if (ctx.Request.Body != null)
            {
                try
                {
                    using (var reader = new StreamReader(ctx.Request.Body))
                    {
                        body = reader.ReadToEnd();
                    }
                }

                catch (Exception e)
                {
                    Log.WarnFormat(ErrorEvaluatingBodyMessage, e.Message, requestId);
                }
            }

            Log.InfoFormat(ReceivedApiRequestMessage, ctx.Request.UserHostAddress, ctx.Request.Method,
                ctx.Request.Url, requestId);

            Log.DebugFormat(ReceivedApiRequestBodyMessage, body, requestId);

            return null;
        };

        private Action<NancyContext> AddToAfter => ctx =>
        {
            if (ctx.Items.TryGetValue(Constants.Request.IdKeyName, out object value) && value != null)
            {
                ctx.Response.Headers.Add(new KeyValuePair<string, string>(Constants.Request.IdHeaderName, value as string ?? string.Empty));
            }

            string body = null;

            if (ctx.Response.Contents != null)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        ctx.Response.Contents.Invoke(ms);
                        ms.Position = 0;
                        var sr = new StreamReader(ms);
                        body = sr.ReadToEnd();
                    }
                }

                catch (Exception e)
                {
                    Log.WarnFormat(ErrorEvaluatingBodyMessage, e.Message, value as string ?? string.Empty);
                }
            }

            // intercept any Unauthorized responses sent by Nancy and add a WWW-Authenticate header
            if (!(ctx.Response is UnauthorizedResponse) && ctx.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var scheme = Context.Environment.GetValue<AuthSettings>().SchemeName;

                if (!ctx.Response.Headers.ContainsKey(WwwAuthenticateHeaderName))
                {
                    ctx.Response.Headers.Add(WwwAuthenticateHeaderName, scheme);
                }
            }

            Log.InfoFormat(ReturningApiResponseMessage, ctx.Response.StatusCode, value == null ? NullString : value as string ?? string.Empty);
            Log.DebugFormat(ReturningApiResponseBodyMessage, body ?? NullString, value == null ? NullString : value as string ?? string.Empty);
        };
    }
}