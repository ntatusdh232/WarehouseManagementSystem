namespace WMS.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext context) : base(context){}

        public async Task<IEnumerable<EmployeeList>> GettAllAsync()
        {
            var employeeList = await _context.employees
                .AsNoTracking()
                .Select(e => new EmployeeList
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName
                }).ToListAsync();

            return employeeList;
        }

        public async Task<EmployeeList> GetEmployeeById(string employeeId)
        {
            var employee = await _context.employees
                .AsNoTracking()
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new EmployeeList
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName
                }).FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            return employee;
        }

        public async Task<EmployeeList> GetEmployeeByName(string employeeName)
        {
            var employee = await _context.employees
                .AsNoTracking()
                .Where(e => e.EmployeeName == employeeName)
                .Select(e => new EmployeeList
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName
                }).FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            return employee;
        }

        public async Task<EmployeeList> Add(EmployeeList employee)
        {
            var employeeId = string.IsNullOrEmpty(employee.EmployeeId)
                ? Guid.NewGuid().ToString()
                : employee.EmployeeId;

 
            var newEmployee = new Employee
            (
                employeeId,
                employee.EmployeeName,
                null
            );

            await _context.employees.AddAsync(newEmployee); 
            await _context.SaveChangesAsync(); 


            return new EmployeeList
            {
                EmployeeId = newEmployee.EmployeeId,
                EmployeeName = newEmployee.EmployeeName

            };
        }


        public async Task<EmployeeList?> Update(EmployeeList updatedEmployee)
        {
            // Tìm employee trong cơ sở dữ liệu
            var employee = await _context.employees.FindAsync(updatedEmployee.EmployeeId);

            if (employee == null)
            {
                return null;
            }

            employee.EmployeeName = updatedEmployee.EmployeeName;

            await _context.SaveChangesAsync();
            return new EmployeeList
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName

            };
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

        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                _context.employees.Add(employee); 
                await _context.SaveChangesAsync(); 
                return employee;
            }
            catch (Exception ex)
            {

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

}

