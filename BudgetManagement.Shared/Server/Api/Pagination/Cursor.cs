using System;
using System.Text;

namespace BudgetManagement.Shared.Server.Api.Pagination
{
    // Represents a cursor to be used in cursor-based pagination.
    public class Cursor
    {
        /// <summary>
        /// A decoded cursor value that indicates the end of a collection.
        /// </summary>
        [Obsolete("This member is deprecated. Consider using Cursor.EmptyCursor instead.")]
        public static readonly string EndOfCollection = "";

        /// <summary>
        /// A decoded cursor value that indicates the start of a collection.
        /// </summary>
        [Obsolete("This member is deprecated. Consider using Cursor.EmptyCursor (with TraversablePaginationResponse) or the null keyword (with PaginationResponse) instead.")]
        public static readonly string StartOfCollection = null;

        /// <summary>
        /// A decoded cursor value that indicates an empty cursor. The meaning of this
        /// cursor value is implementation dependent.
        /// </summary>
        public static readonly string EmptyCursor = "";

        private Cursor()
        {

        }

        /// <summary>
        /// Constructs an instance of Cursor with the supplied value. The value will be encoded so that 
        /// the value obtained from a Cursor instance will always be an opaque string. This allows
        /// a pagination implementor freedom to choose and change the cursor type without affecting
        /// an API consumer. This type and the related types of <b>PaginationResponse</b> and <b>Page</b> 
        /// do not dictate implementation details such as the data type of a cursor value (except that it 
        /// be convertable into a string form for encoding purposes) and the cursor-indexing scheme (such 
        /// as zero-based vs. one-based). The flexiblity of this family of types allows a pagination implementor 
        /// to define such details according to their specific data and needs.
        /// </summary>
        /// <param name="value">The value of the cursor.</param>
        public Cursor(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = Encode(value);
        }

        /// <summary>
        /// The encoded representation of the cursor value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the decoded representation of the cursor value.
        /// </summary>
        /// <returns>The decoded value.</returns>
        public string GetDecodedValue()
        {
            return Decode(Value);
        }

        /// <summary>
        /// Encodes an input value using the default encoding scheme of Cursor. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>An encoded value.</returns>
        public static string Encode(string input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
        }

        /// <summary>
        /// Decodes an input value using the default encoding scheme of Cursor. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A decoded value.</returns>
        public static string Decode(string input)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(input));
        }
    }
}