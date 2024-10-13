using DocumentFormat.OpenXml.Spreadsheet;

namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeList>> GetEmployeeLists();
        Task<EmployeeList> GetEmployeeId(string employeeId);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetSort(string sortField, string sortDirection, IEnumerable<Employee> employees);
        IXLWorksheet? GetEmployeeworksheet(IEnumerable<Employee> employees, IXLWorksheet? worksheet);
        Task<Employee> AddEmployee(Employee employee);
        List<Employee> GetPageEmployees(IEnumerable<Employee> employees, int pageNumber, int pageSize);
        Task UpdateEmployee(EmployeeList employee);




    }
}
