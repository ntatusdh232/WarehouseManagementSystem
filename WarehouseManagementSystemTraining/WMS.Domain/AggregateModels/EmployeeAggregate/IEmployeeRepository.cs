namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeList>> GetEmployeeLists();
        Task<EmployeeList> GetEmployeeId(string employeeId);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetSort(string sortField, string sortDirection, IEnumerable<Employee> employees);

        
    }
}
