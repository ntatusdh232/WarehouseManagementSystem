
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetAllGoodsIssueIdsQueryHandler : IRequestHandler<GetAllGoodsIssueIdsQuery, IEnumerable<string>>
{
    public Task<IEnumerable<string>> Handle(GetAllGoodsIssueIdsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
