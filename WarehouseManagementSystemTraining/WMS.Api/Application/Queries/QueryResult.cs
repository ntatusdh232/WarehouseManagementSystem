namespace WMS.Api.Application.Queries
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Result { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;

        public QueryResult(IEnumerable<T> result, int totalItems)
        {
            Result = result;
            TotalItems = totalItems;
        }
    }
}
