namespace WMS.Api.Application.Queries.Employees;

public class GetEmployeeByIdQuery : PaginatedQuery, IRequest<QueryResult<EmployeeViewModel>>
{
}
