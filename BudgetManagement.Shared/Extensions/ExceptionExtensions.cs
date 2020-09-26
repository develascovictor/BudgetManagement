using BudgetManagement.Shared.Response.Models;
using FluentValidation.Results;
using log4net;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace BudgetManagement.Shared.Extensions
{
    public static class ExceptionExtensions
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Method to return an BadRequestResponse after logging a Null Request
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CommandResult<T> GetBadResponse<T>(object parameters, [CallerMemberName] string method = null, [CallerFilePath] string path = null)
            where T : class
        {
            const string details = "Null Request";
            var data = GetData(parameters, method, path);

            var message = GetDetailedMessage(data, details);
            Log.Warn(message);

            var badRequestResponse = CommandResult<T>.BadRequest(details);
            return badRequestResponse;
        }

        /// <summary>
        /// Method to return an BadRequestResponse after logging a ValidationResult
        /// </summary>
        /// <param name="validationResult"></param>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CommandResult<T> GetBadResponse<T>(this ValidationResult validationResult, object parameters, [CallerMemberName] string method = null, [CallerFilePath] string path = null)
            where T : class
        {
            const string validationError = "ValidationError";
            var data = GetData(parameters, method, path);
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            var details = $"{validationError}{Environment.NewLine}{string.Join(" ", errors)}";

            var message = GetDetailedMessage(data, details);
            Log.Warn(message);

            var badRequestResponse = CommandResult<T>.BadRequest(details);
            return badRequestResponse;
        }

        /// <summary>
        /// Method to return an BadRequestResponse after logging an Exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CommandResult<T> GetBadResponse<T>(this Exception exception, object parameters, [CallerMemberName] string method = null, [CallerFilePath] string path = null)
            where T : class
        {
            exception.GetErrorLogResult(parameters, method, path);
            var badRequestResponse = CommandResult<T>.BadRequest(exception.Message);

            return badRequestResponse;
        }

        /// <summary>
        /// Method to return an InternalServerErrorResponse after logging an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="apiModule"></param>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CommandResult<T> GetInternalServerErrorResponse<T>(this Exception exception, object parameters, [CallerMemberName] string method = null, [CallerFilePath] string path = null)
            where T : class
        {
            exception.GetErrorLogResult(parameters, method, path);
            var internalServerErrorResponse = CommandResult<T>.InternalServerError();

            return internalServerErrorResponse;
        }

        /// <summary>
        /// Method to log an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetErrorLogResult(this Exception exception, object parameters, [CallerMemberName] string method = null, [CallerFilePath] string path = null)
        {
            var data = GetData(parameters, method, path);
            var fullExceptionMessage = exception.GetFullExceptionMessage();

            var message = GetDetailedMessage(data, fullExceptionMessage);
            Log.Error(message, exception);

            return message;
        }

        /// <summary>
        /// Method to return an anonymous object that details the Class, Method and Params
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="method"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static object GetData(object parameters, string method, string path)
        {
            var className = GetClassName(path);
            var data = new { Class = className, Method = method, Params = parameters };

            return data;
        }

        /// <summary>
        /// Get class name out of a complete file path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string GetClassName(string path)
        {
            var location = path;

            if (location == null)
            {
                return null;
            }

            if (!location.Contains("\\"))
            {
                return RemoveCsExtension(location);
            }

            var temp = location.Split('\\');
            return RemoveCsExtension(temp[temp.Length - 1]);
        }

        /// <summary>
        /// Get formatted message detailing all data and specific details from error
        /// </summary>
        /// <param name="data"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        private static string GetDetailedMessage(object data, string details)
        {
            var message = new StringBuilder();
            message.Append(Environment.NewLine);
            message.Append("********** BEGIN EXCEPTION MESSAGE **********");
            message.Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.AppendLine("Data: ");
            message.Append(data.Stringify());
            message.Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append(details);
            message.Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("********** END EXCEPTION MESSAGE **********");

            return message.ToString();
        }

        /// <summary>
        /// Build a detailed message obtained from exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static string GetFullExceptionMessage(this Exception exception)
        {
            var message = new StringBuilder();

            //Prevent that this loops forever in case there is no end to the inner exceptions
            for (var i = 0; i < 10; i++)
            {
                if (exception != null)
                {
                    if (i > 0)
                    {
                        message.Append(Environment.NewLine);
                        message.Append(Environment.NewLine);
                        message.AppendLine($"Inner Exception #{i}:");
                        message.Append(Environment.NewLine);
                    }

                    message.Append("Message: ");
                    message.AppendLine(exception.Message);

                    var type = exception.GetType();
                    message.Append(Environment.NewLine);
                    message.Append("Type: ");
                    message.AppendLine(type.ToString());

                    message.Append(Environment.NewLine);
                    message.Append("Source: ");
                    message.AppendLine(exception.Source);

                    if (type == typeof(DbEntityValidationException))
                    {
                        message.Append(Environment.NewLine);
                        message.AppendLine("Entity Validation Details: ");

                        //message.Append(((DbEntityValidationException) exception).EntityValidationErrors.Aggregate(string.Empty, (current1, evr) => current1 + $"Entity of type \"{evr.Entry.Entity.GetType().Name}\" in state \"{evr.Entry.State}\" has the following validation errors:{Environment.NewLine}{evr.ValidationErrors.Aggregate(string.Empty, (current, ve) => current + $"\t- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"{Environment.NewLine}")}"));

                        foreach (var evr in ((DbEntityValidationException)exception).EntityValidationErrors)
                        {
                            message.AppendLine($"Entity of type \"{evr.Entry.Entity.GetType().Name}\" in state \"{evr.Entry.State}\" has the following validation errors:");

                            foreach (var ve in evr.ValidationErrors)
                            {
                                message.AppendLine($"\t- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                            }
                        }
                    }

                    //else if (type == typeof(PropertyBindingException))
                    //{
                    //    var propertyBindingException = (PropertyBindingException)exception;
                    //    message.Append(Environment.NewLine);
                    //    message.Append("Property: ");
                    //    message.AppendLine(propertyBindingException.PropertyName);

                    //    message.Append(Environment.NewLine);
                    //    message.Append("Value: ");
                    //    message.AppendLine(propertyBindingException.AttemptedValue);
                    //}

                    message.Append(Environment.NewLine);
                    message.AppendLine("Stack Trace: ");
                    message.Append(exception.StackTrace);

                    exception = exception.InnerException;
                }
            }

            return message.ToString();
        }

        /// <summary>
        /// Method to remove the .cs file extension from string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string RemoveCsExtension(string name) => name.Replace(".cs", "");
    }
}