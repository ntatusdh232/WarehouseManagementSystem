namespace WMS.Api.Application.Queries.Employees
{
    public class GetEmployeeByIdQuery : PaginatedQuery, IRequest<EmployeeViewModel>
    {
        public string EmployeeId { get; set; }
        public GetEmployeeByIdQuery(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}


