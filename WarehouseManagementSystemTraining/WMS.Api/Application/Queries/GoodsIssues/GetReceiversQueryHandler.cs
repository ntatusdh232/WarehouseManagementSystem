
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetReceiversQueryHandler : IRequestHandler<GetReceiversQuery, List<string>>
{
    public Task<List<string>> Handle(GetReceiversQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
