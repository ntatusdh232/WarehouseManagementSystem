namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class GetAllIdsQuery : PaginatedQuery, IRequest<IEnumerable<string>>
    {
        public GetAllIdsQuery()
        {
        }
    }
}


