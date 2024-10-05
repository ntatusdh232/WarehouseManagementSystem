namespace ChaWarehouseMicroservice.Domain.AggregateModels.EmployeeAggregate;

public class Employee : Entity, IAggregateRoot
{
    public string EmployeeId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public Employee(string employeeId, string firstName, string lastName, DateTime dateOfBirth)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }
}