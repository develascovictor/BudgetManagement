using BudgetManagement.Shared.Server.Api.Pagination;

namespace BudgetManagement.Service.Api.Utilities
{
    public static class PaginationResponseFactory
    {
        public static TraversablePaginationResponse GetPaginationResponse(int index, int limit, long total)
        {
            //TODO: Limit must be above 0
            var totalPages = total / limit + (total % limit > 0 ? 1 : 0); // Remainder > 1 adds a page
            var currentPage = index / limit; // 0 based pagination

            var nextPage = currentPage + 1;
            var prevPage = currentPage - 1;
            var lastPage = totalPages - 1;

            var nextSkip = nextPage * limit;
            var nextCursor = nextSkip >= total ? Cursor.EmptyCursor : nextSkip.ToString();

            var prevSkip = prevPage * limit;
            var prevCursor = prevSkip <= 0 ? Cursor.EmptyCursor : prevSkip.ToString();

            var lastSkip = lastPage * limit;
            var lastCursor = lastSkip <= 0 ? Cursor.EmptyCursor : lastSkip.ToString();

            var paginationRes = new TraversablePaginationResponse(prevCursor, nextCursor, Cursor.EmptyCursor, lastCursor, total);

            return paginationRes;
        }
    }
}