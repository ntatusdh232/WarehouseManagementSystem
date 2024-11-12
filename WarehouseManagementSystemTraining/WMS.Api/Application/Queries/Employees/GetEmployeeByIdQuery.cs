namespace WMS.Api.Application.Queries.Employees
{
    public class GetEmployeeByIdQuery : PaginatedQuery, IRequest<QueryResult<EmployeeViewModel>>
    {
        public string EmployeeId { get; set; }
        public GetEmployeeByIdQuery(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}


