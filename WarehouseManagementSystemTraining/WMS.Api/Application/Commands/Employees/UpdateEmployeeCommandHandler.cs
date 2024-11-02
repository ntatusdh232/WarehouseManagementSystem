
namespace WMS.Api.Application.Commands.Employees;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        if(employee is null)
        {
            throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
        }
        employee.Update(request.EmployeeName);
        return await _employeeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
