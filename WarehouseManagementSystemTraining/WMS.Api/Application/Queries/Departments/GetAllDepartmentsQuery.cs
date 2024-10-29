namespace WMS.Api.Application.Queries.Departments
{
    public class GetAllDepartmentsQuery : PaginatedQuery, IRequest<IEnumerable<DepartmentViewModel>>
    {
    }
}
