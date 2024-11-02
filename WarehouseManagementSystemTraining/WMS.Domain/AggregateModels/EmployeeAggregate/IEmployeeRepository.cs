namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GettAllAsync();
        Task<Employee> GetEmployeeById(string employeeId);
        Task<Employee> GetEmployeeByName(string employeeName);
        Task<Employee> Add(Employee employee);
        Task<Employee?> Update(Employee updatedEmployee);




        //Task UpdateEmployee(Employee employee);
        //Task<Employee> AddEmployee(Employee employee);
        //IEnumerable<Employee> GetEmployees();
        //IEnumerable<Employee> GetSort(string sortField, string sortDirection, IEnumerable<Employee> employees);
        //IXLWorksheet? GetEmployeeworksheet(IEnumerable<Employee> employees, IXLWorksheet? worksheet);
        //List<Employee> GetPageEmployees(IEnumerable<Employee> employees, int pageNumber, int pageSize);
        
    }
}
