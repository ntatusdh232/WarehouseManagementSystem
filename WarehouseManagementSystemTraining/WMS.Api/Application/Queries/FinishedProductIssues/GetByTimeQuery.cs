namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetByTimeQuery : PaginatedQuery, IRequest<IEnumerable<FinishedProductIssueViewModel>>
{
    public TimeRangeQuery Query { get; set; }

    public GetByTimeQuery(TimeRangeQuery query)
    {
        Query = query;
    }
}
