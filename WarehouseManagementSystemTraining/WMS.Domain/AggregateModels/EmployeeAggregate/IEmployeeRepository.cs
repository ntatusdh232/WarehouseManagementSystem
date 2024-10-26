namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<EmployeeList>> GettAllAsync();
        Task<EmployeeList> GetEmployeeById(string employeeId);
        Task<EmployeeList> GetEmployeeByName(string employeeName);
        Task<EmployeeList> Add(EmployeeList employee);
        Task<EmployeeList?> Update(EmployeeList updatedEmployee);




        Task UpdateEmployee(EmployeeList employee);
        Task<Employee> AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetSort(string sortField, string sortDirection, IEnumerable<Employee> employees);
        IXLWorksheet? GetEmployeeworksheet(IEnumerable<Employee> employees, IXLWorksheet? worksheet);
        List<Employee> GetPageEmployees(IEnumerable<Employee> employees, int pageNumber, int pageSize);
        
    }
}
