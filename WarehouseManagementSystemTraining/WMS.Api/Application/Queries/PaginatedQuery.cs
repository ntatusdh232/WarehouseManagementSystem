namespace WMS.Api.Application.Queries
{
    public class PaginatedQuery
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
