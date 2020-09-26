using System.Collections.Generic;

namespace BudgetManagement.Shared.Pagination.Models
{
    public class DataPage<T>
    {
        public IReadOnlyCollection<T> Data { get; }
        public PageOptions PageOptions { get; }
        public long Total { get; }

        public DataPage(IReadOnlyCollection<T> data, PageOptions pageOptions, long total)
        {
            Data = data;
            PageOptions = pageOptions;
            Total = total;
        }
    }
}