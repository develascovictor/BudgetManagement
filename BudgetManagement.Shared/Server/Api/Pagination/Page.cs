using System.Collections.Generic;

namespace BudgetManagement.Shared.Server.Api.Pagination
{
    /// <summary>
    /// A single page of resources with included pagination information. This type can be serialized and
    /// returned to a consumer by an API endpoint. This type and the related types such as <b>Cursor</b>,  
    /// <b>PaginationResponse</b> and <b>TraversablePaginationResponse</b> do not dictate implementation 
    /// details such as the data type of a cursor value (except that it be convertable into a string form 
    /// for encoding purposes) and the cursor-indexing scheme (such as zero-based vs. one-based). The 
    /// flexiblity of this family of types allows a pagination implementor to define such details according 
    /// to their specific data and needs.
    /// </summary>
    /// <typeparam name="T">The type of the resource contained in the response.</typeparam>
    public class Page<T> where T : class
    {
        /// <summary>
        /// A collection of resources.
        /// </summary>
        public List<T> Resources { get; }

        /// <summary>
        /// Pagination information related to this page of resources.
        /// </summary>
        public PaginationResponse Paging { get; }

        /// <summary>
        /// Constructs an instance of Page.
        /// </summary>
        /// <param name="resources">A collection of resources to be returned in response to an API request.</param>
        /// <param name="paginationResponse">Pagination information related to this page of resources.</param>
        public Page(List<T> resources, PaginationResponse paginationResponse)
        {
            Resources = resources;
            Paging = paginationResponse;
        }
    }
}