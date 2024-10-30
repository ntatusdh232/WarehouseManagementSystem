

namespace WMS.Api.Application.Queries.Employees;

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeViewModel>>
{
    public Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
