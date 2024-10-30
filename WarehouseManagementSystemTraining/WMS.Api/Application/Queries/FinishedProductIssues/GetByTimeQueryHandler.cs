
namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetByTimeQueryHandler : IRequestHandler<GetByTimeQuery, IEnumerable<FinishedProductIssueViewModel>>
{
    public Task<IEnumerable<FinishedProductIssueViewModel>> Handle(GetByTimeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
