namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetByTimeQuery : PaginatedQuery, IRequest<IEnumerable<FinishedProductIssueViewModel>>
{
}
