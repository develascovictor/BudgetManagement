using System.Collections.Generic;
using System.Net;

namespace BudgetManagement.Shared.Response.Models
{
    public class CommandResult<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Result { get; set; }

        public List<string> ErrorList { get; set; } = new List<string>();

        private CommandResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        private CommandResult(HttpStatusCode statusCode, T result)
        {
            StatusCode = statusCode;
            Result = result;
        }

        private CommandResult(HttpStatusCode statusCode, List<string> errorList)
        {
            StatusCode = statusCode;
            ErrorList = errorList;
        }

        public static CommandResult<T> Ok(T result)
        {
            return new CommandResult<T>(HttpStatusCode.OK, result);
        }

        public static CommandResult<T> NotFound()
        {
            return new CommandResult<T>(HttpStatusCode.NotFound);
        }

        public static CommandResult<T> BadRequest()
        {
            return new CommandResult<T>(HttpStatusCode.BadRequest);
        }

        public static CommandResult<T> BadRequest(string errorMessage)
        {
            return new CommandResult<T>(HttpStatusCode.BadRequest, new List<string> { errorMessage });
        }

        public static CommandResult<T> BadRequest(List<string> errorList)
        {
            return new CommandResult<T>(HttpStatusCode.BadRequest, errorList);
        }

        public static CommandResult<T> InternalServerError()
        {
            return new CommandResult<T>(HttpStatusCode.InternalServerError);
        }
    }
}