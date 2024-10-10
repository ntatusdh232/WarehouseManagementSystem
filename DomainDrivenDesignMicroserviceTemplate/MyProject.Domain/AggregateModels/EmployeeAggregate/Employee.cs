namespace MyProject.Domain.AggregateModels.EmployeeAggregate;

public class Employee : Entity, IAggregateRoot
{
    public string EmployeeId { get; private set; }  
    public string EmployeeName { get; private set; }

    public Employee(string employeeId, string employeeName)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Employee()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}