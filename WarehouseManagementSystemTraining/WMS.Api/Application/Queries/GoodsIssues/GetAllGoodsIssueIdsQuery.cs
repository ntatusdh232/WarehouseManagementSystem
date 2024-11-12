namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetAllGoodsIssueIdsQuery : PaginatedQuery, IRequest<IEnumerable<string>>
    {
        public bool IsExported { get; set; }
    }
}


