using WMS.Domain.AggregateModels.EmployeeAggregate;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;


    public EmployeeRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EmployeeList>> GetEmployeeLists()
    {
        var employeeList = await _context.employees
            .AsNoTracking() 
            .Select(e => new EmployeeList
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
            }).ToListAsync();

        return employeeList;
    }

    public async Task<EmployeeList> GetEmployeeId(string employeeId)
    {
        var employee = await _context.employees
            .AsNoTracking()
            .Where(e => e.EmployeeId == employeeId)
            .Select(e => new EmployeeList
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
            }).FirstOrDefaultAsync();

        return employee;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.employees.AsNoTracking().ToList();
    }

    public IEnumerable<Employee> GetSort(string sortField, string sortDirection, IEnumerable<Employee> employees)
    {

        switch (sortField)
        {
            case "EmployeeId":
                employees = sortDirection.ToLower() == "desc"
                    ? employees.OrderByDescending(e => e.EmployeeId).ToList()
                    : employees.OrderBy(e => e.EmployeeId).ToList();
                break;

            case "EmployeeName":
                employees = sortDirection.ToLower() == "desc"
                    ? employees.OrderByDescending(e => e.EmployeeName).ToList()
                    : employees.OrderBy(e => e.EmployeeName).ToList();
                break;

            default:
                employees = employees.OrderBy(e => e.EmployeeId).ToList();
                break;
        }


        return employees;
        }
}
