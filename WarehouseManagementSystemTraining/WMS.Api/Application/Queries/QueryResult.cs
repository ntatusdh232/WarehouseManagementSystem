namespace WMS.Api.Application.Queries
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;

        public QueryResult(IEnumerable<T> items, int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
