using BudgetManagement.Shared.Response.Models;
using Filtering.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers.Base
{
    public abstract class BaseController : ApiController
    {
        protected T GetFromQueryString<T>() where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var valueAsString = HttpContext.Current.Request.QueryString[property.Name];

                if (property.Name.ToLower() == "filter")
                {
                    valueAsString = RequestExtensions.GetFilterRequest(HttpContext.Current.Request.Url.Query);
                }

                if (valueAsString == null)
                {
                    continue;
                }

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(obj, valueAsString, null);
                }

                else if (property.PropertyType == typeof(int))
                {
                    var value = int.Parse(valueAsString);
                    property.SetValue(obj, value, null);
                }
            }

            return obj;
        }

        protected IHttpActionResult GetResponse<T>(CommandResult<T> commandResult) where T : class
        {
            switch (commandResult.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        return Ok(commandResult.Result);
                    }

                case HttpStatusCode.BadRequest:
                    {
                        return BadRequest(commandResult.ErrorList.Aggregate(string.Empty, (current, item) => $"{current}- {item}\n"));
                    }

                case HttpStatusCode.InternalServerError:
                    {
                        return InternalServerError();
                    }

                default:
                    {
                        throw new Exception($"Invalid Http Status Code: {commandResult.StatusCode}");
                    }
            }
        }
    }
}