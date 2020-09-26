using BudgetManagement.Shared.Server.Api.Pagination;
using Nancy;
using System;

namespace BudgetManagement.Shared.Server.Api.ExtensionMethods
{
    public static class NancyRequestExtensions
    {
        private const string CursorString = "cursor";
        private const string LimitString = "limit";

        private const string InvalidLimitValueMessage = "The limit value supplied in the request query string is invalid. A limit must have a value of 0 or greater.";
        private const string InvalidCursorMessage = "The cursor value supplied in the request query string could not be parsed.";
        private const string InvalidLimitMessage = "The limit value supplied in the request query string could not be parsed.";

        /// <summary>
        /// Returns pagination information obtained from the query string of an API request.
        /// </summary>
        /// <param name="request">The request to parse for pagination information.</param>
        /// <returns>A pagination object that contains the pagination information.</returns>
        /// <exception cref="ArgumentException">Thrown if the value for limit or cursor is invalid.</exception>
        public static PaginationRequest GetPaginationInfo(this Request request)
        {
            return GetPaginationInfo(request, PaginationRequest.DefaultLimit);
        }

        /// <summary>
        /// Returns pagination information derived from the query string of an API request.
        /// </summary>
        /// <param name="request">The request to parse for pagination information.</param>
        /// <param name="defaultLimit">A limit to use if the query string in <paramref name="request"/></param>
        /// does not contain a limit value. 
        /// <returns>A pagination object that contains the pagination information.</returns>
        /// <exception cref="ArgumentException">Thrown if the value for limit or cursor is invalid.</exception>
        public static PaginationRequest GetPaginationInfo(this Request request, int defaultLimit)
        {
            if (defaultLimit < 0)
            {
                throw new ArgumentException(nameof(defaultLimit));
            }
            string decodedCursor;

            try
            {
                var encodedCursor = request.Query[CursorString];
                decodedCursor = encodedCursor == null ? Cursor.StartOfCollection : Cursor.Decode(encodedCursor);
            }

            catch (Exception e)
            {
                throw new ArgumentException(InvalidCursorMessage, e);
            }

            int? limit;

            try
            {
                var qsLimit = (int?)request.Query[LimitString];
                limit = qsLimit == null || qsLimit.Value > defaultLimit ? defaultLimit : qsLimit;
            }

            catch (Exception e)
            {
                throw new ArgumentException(InvalidLimitMessage, e);
            }

            if (limit < 0)
            {
                throw new ArgumentException(InvalidLimitValueMessage);
            }

            var paginationInfo = new PaginationRequest
            {
                Cursor = decodedCursor,
                Limit = limit.Value
            };

            return paginationInfo;
        }
    }
}