
namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetProductIssueByIdQueryHandler : IRequestHandler<GetProductIssueByIdQuery, QueryResult<FinishedProductIssueViewModel>>
{
    public Task<QueryResult<FinishedProductIssueViewModel>> Handle(GetProductIssueByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
