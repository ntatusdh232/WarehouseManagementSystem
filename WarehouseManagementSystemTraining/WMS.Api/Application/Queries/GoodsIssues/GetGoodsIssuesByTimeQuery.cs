namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetGoodsIssuesByTimeQuery : PaginatedQuery, IRequest<IEnumerable<GoodsIssueViewModel>>
{
    public TimeRangeQuery Query { get; set; }
    public bool isExported { get; set; }

    public GetGoodsIssuesByTimeQuery(TimeRangeQuery query, bool isexported)
    {
        Query = query;
        isExported = isexported;
    }
}
