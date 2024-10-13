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

    public IXLWorksheet? GetEmployeeworksheet(IEnumerable<Employee> employees, IXLWorksheet? worksheet)
    {
        worksheet = worksheet ?? new XLWorkbook().Worksheets.Add("Employees");

        worksheet.Cell(1, 1).Value = "EmployeeId";
        worksheet.Cell(1, 2).Value = "EmployeeName";

        for (int i = 0; i < employees.Count(); i++)
        {
            var employee = employees.ElementAt(i);
            worksheet.Cell(i + 2, 1).Value = employee.EmployeeId;
            worksheet.Cell(i + 2, 2).Value = employee.EmployeeName;
        }

        return worksheet;
    }

    // thêm Employee vào Database
    public async Task<Employee> AddEmployee(Employee employee)
    {
        try
        {
            _context.employees.Add(employee); // Thêm nhân viên vào DbSet
            await _context.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
            return employee;
        }
        catch (Exception ex)
        {
            // Xử lý lỗi nếu cần
            throw new InvalidOperationException("Không thể thêm nhân viên vào cơ sở dữ liệu: " + ex.Message);
        }
    }

    public List<Employee> GetPageEmployees(IEnumerable<Employee> employees, int pageNumber, int pageSize)
    {
        var pagedEmployees = employees
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return pagedEmployees;
    }

    public async Task UpdateEmployee(EmployeeList employee)
    {
        var existingEmployee = await _context.employees.FindAsync(employee.EmployeeId);
        if (existingEmployee != null)
        {
            existingEmployee.EmployeeName = employee.EmployeeName;

            _context.employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }
    }


}
