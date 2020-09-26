using System;

namespace BudgetManagement.Shared.Server.Api.Pagination
{
    /// <summary>
    /// Contains cursor-based pagination information for use in an API response. This type extends   
    /// PaginationResponse to include information useful for bi-directional traversal of the collection
    /// to which the cursor refers. This type is used, in combination
    /// with a page of resources, to construct a <b>Page</b> instance that can be serialized and returned by an 
    /// API endpoint. This type and the related types of <b>Cursor</b> and <b>Page</b> do not dictate implementation 
    /// details such as the data type of a cursor value (except that it be convertable into a string form for encoding
    /// purposes) and the cursor-indexing scheme (such as zero-based vs. one-based). The flexiblity of this family of types
    /// allows a pagination implementor to define such details according to their specific data and needs.
    /// </summary>
    public class TraversablePaginationResponse : PaginationResponse
    {
        /// <summary>
        /// A cursor pointing to the previous page of data in the collection. The value will be a representation of the
        /// cursor value encoded according to the default encoding scheme of the <b>Cursor</b> type. This value can be 
        /// used in a subsequent request to return the previous page of data from the collection.
        /// </summary>
        public string PrevCursor { get; }

        /// <summary>
        /// A cursor pointing to the final page of data in the collection. The value will be a representation of the
        /// cursor value encoded according to the default encoding scheme of the <b>Cursor</b> type. This value can be 
        /// used in a subsequent request to return the last page of data from the collection.
        /// </summary>
        public string LastCursor { get; }

        /// <summary>
        /// A cursor pointing to the first page of data in the collection. The value will be a representation of the
        /// cursor value encoded according to the default encoding scheme of the <b>Cursor</b> type. This value can be 
        /// used in a subsequent request to return the first page of data from the collection.
        /// </summary>
        public string FirstCursor { get; }

        /// <summary>
        /// Constructs an instance of TraversablePaginationResponse using the supplied cursor values. All values
        /// will be encoded according to the default encoding scheme of the <b>Cursor</b> type.
        /// </summary>
        /// <param name="previousCursorValue">A value pointing to the previous page of data in a collection. By
        /// convention, supplying a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// start of a collection.
        /// </param>
        /// <param name="nextCursorValue">A value pointing to the next page of data in a collection.By
        /// convention, supplying a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// end of a collection.</param>
        /// <param name="firstCursorValue">A value pointing to the first page of data in a collection.</param>
        /// <param name="lastCursorValue">A value pointing to the final page of data in a collection.</param>
        /// <param name="total">The total number of items in the collection of resources, of which any page
        /// being returned with this PaginationResponse is a subset.</param>
        public TraversablePaginationResponse(string previousCursorValue, string nextCursorValue,
            string firstCursorValue, string lastCursorValue, long total)
            : this(new Cursor(previousCursorValue), new Cursor(nextCursorValue), new Cursor(firstCursorValue),
                new Cursor(lastCursorValue), total)
        {
        }

        /// <summary>
        /// Constructs an instance of TraversablePaginationResponse using the supplied Cursor instances.
        /// </summary>
        /// <param name="previousCursor">A cursor pointing to the previous page of data in a collection. By convention,
        /// supplying a cursor with a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// start of a collection.</param>
        /// <param name="nextCursor">A cursor pointing to the next page of data in a collection. By convention,
        /// supplying a cursor with a value of Cursor.EmptyCursor for this parameter indicates positioning at the
        /// end of a collection.</param>
        /// <param name="firstCursor">A value pointing to the first page of data in a collection.</param>
        /// <param name="lastCursor">A cursor pointing to the final page of data in a collection.</param>
        /// <param name="total">The total number of items in the collection of resources, of which any page
        /// being returned with this PaginationResponse is a subset.</param>
        public TraversablePaginationResponse(Cursor previousCursor, Cursor nextCursor, Cursor firstCursor, Cursor lastCursor, long total)
            : base(nextCursor, total)
        {
            if (previousCursor == null)
            {
                throw new ArgumentNullException(nameof(previousCursor));
            }

            if (firstCursor == null)
            {
                throw new ArgumentNullException(nameof(firstCursor));
            }

            if (lastCursor == null)
            {
                throw new ArgumentNullException(nameof(lastCursor));
            }

            PrevCursor = previousCursor.Value ?? throw new ArgumentNullException(CursorValueCannotBeNull, new ArgumentNullException());
            FirstCursor = firstCursor.Value ?? throw new ArgumentNullException(CursorValueCannotBeNull, new ArgumentNullException());
            LastCursor = lastCursor.Value ?? throw new ArgumentNullException(CursorValueCannotBeNull, new ArgumentNullException());
        }
    }
}