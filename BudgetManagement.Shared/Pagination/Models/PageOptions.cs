namespace BudgetManagement.Shared.Pagination.Models
{
    public class PageOptions
    {
        public int Index { get; }
        public int Limit { get; }

        public PageOptions(int index, int limit)
        {
            Index = index;
            Limit = limit;
        }
    }
}