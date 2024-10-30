
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsIssueViewModel>>
{
    public Task<IEnumerable<GoodsIssueViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
