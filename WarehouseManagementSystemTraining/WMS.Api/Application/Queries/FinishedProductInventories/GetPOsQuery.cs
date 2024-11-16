namespace WMS.Api.Application.Queries.FinishedProductInventories
{
    public class GetPOsQuery : PaginatedQuery, IRequest<IEnumerable<string>>
    {
        public GetPOsQuery()
        {
        }
    }
}
