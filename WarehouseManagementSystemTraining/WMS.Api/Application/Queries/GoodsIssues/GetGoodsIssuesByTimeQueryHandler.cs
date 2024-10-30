
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetGoodsIssuesByTimeQueryHandler : IRequestHandler<GetGoodsIssuesByTimeQuery, IEnumerable<GoodsIssueViewModel>>
{
    public Task<IEnumerable<GoodsIssueViewModel>> Handle(GetGoodsIssuesByTimeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
