using WMS.Api.Application.Queries.FinishedProductIssuesl;

namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetAllIdsQueryHandler : IRequestHandler<GetAllIdsQuery, IEnumerable<string>>
{
    public Task<IEnumerable<string>> Handle(GetAllIdsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
