
namespace WMS.Api.Application.Queries.Employees;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, QueryResult<EmployeeViewModel>>
{
    public Task<QueryResult<EmployeeViewModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
