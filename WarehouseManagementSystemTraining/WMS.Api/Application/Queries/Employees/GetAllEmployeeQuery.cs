namespace WMS.Api.Application.Queries.Employees;

public class GetAllEmployeeQuery : PaginatedQuery, IRequest<IEnumerable<EmployeeViewModel>>
{
}
