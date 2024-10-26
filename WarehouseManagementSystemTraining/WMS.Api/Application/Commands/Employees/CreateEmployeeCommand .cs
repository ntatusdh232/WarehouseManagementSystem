namespace WMS.Api.Application.Commands.Employees
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public CreateEmployeeCommand(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }

    }
}
