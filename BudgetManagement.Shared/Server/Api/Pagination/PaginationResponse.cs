using System;

namespace BudgetManagement.Shared.Server.Api.Pagination
{
    /// <summary>
    /// Contains cursor-based pagination information for use in an API response. This type is used, in combination
    /// with a page of resources, to construct a <b>Page</b> instance that can be serialized and returned by an 
    /// API endpoint. This type and the related types of <b>Cursor</b> and <b>Page</b> do not dictate implementation 
    /// details such as the data type of a cursor value (except that it be convertable into a string form for encoding
    /// purposes) and the cursor-indexing scheme (such as zero-based vs. one-based). The flexiblity of this family of types
    /// allows a pagination implementor to define such details according to their specific data and needs.
    /// </summary>
    public class PaginationResponse
    {
        protected const string CursorValueCannotBeNull = "The Value property of the supplied Cursor cannot be null.";

        /// <summary>
        /// A cursor pointing to the next page of data. The value will be a representation of the
        /// cursor value encoded according to the default encoding scheme of the <b>Cursor</b> type. This value can be 
        /// used in a subsequent request to return the next page of data from the collection.
        /// </summary>
        public string NextCursor { get; }

        /// <summary>
        /// The total number of items in the collection of resources, of which any page being returned with this
        /// PaginationResponse is a subset. 
        /// </summary>
        public long Total { get; }

        /// <summary>
        /// Constructs an instance of PaginationResponse using the supplied cursor value.
        /// </summary>
        /// <param name="nextCursorValue">A cursor value. This value will be encoded according to the default
        /// encoding scheme of the <b>Cursor</b> type. By
        /// convention, supplying a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// end of a collection.</param>
        /// <param name="total">The total number of items in the collection of resources, of which any page
        /// being returned with this PaginationResponse is a subset.</param>
        public PaginationResponse(string nextCursorValue, long total) : this(new Cursor(nextCursorValue), total)
        {

        }

        /// <summary>
        /// Constructs an instance of PaginationResponse using the supplied Cursor instance.
        /// </summary>
        /// <param name="nextCursor">A cursor pointing to the next page of data in a collection. By convention,
        /// supplying a cursor with a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// end of a collection.</param>
        /// <param name="total">The total number of items in the collection of resources, of which any page
        /// being returned with this PaginationResponse is a subset.</param>
        public PaginationResponse(Cursor nextCursor, long total)
        {
            if (nextCursor == null)
            {
                throw new ArgumentNullException(nameof(nextCursor));
            }

            NextCursor = nextCursor.Value ?? throw new ArgumentNullException(CursorValueCannotBeNull, new ArgumentNullException());
            Total = total;
        }
    }
}