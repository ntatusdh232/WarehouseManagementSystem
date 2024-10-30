
namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetAllReceiversQueryHandler : IRequestHandler<GetAllReceiversQuery, IEnumerable<string>>
{
    public Task<IEnumerable<string>> Handle(GetAllReceiversQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
