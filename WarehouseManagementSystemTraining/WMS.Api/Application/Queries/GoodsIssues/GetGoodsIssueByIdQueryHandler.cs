
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetGoodsIssueByIdQueryHandler : IRequestHandler<GetGoodsIssueByIdQuery, QueryResult<GoodsIssueViewModel>>
{
    public Task<QueryResult<GoodsIssueViewModel>> Handle(GetGoodsIssueByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
