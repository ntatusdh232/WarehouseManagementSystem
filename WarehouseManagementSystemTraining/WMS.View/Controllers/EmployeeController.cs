namespace WMS.View.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Employee(string sortField = "EmployeeId", string sortDirection = "asc", int pageNumber = 1, int pageSize = 10)
        {
            var employees = _employeeRepository.GetEmployees();
            var totalEmployees = employees.Count();

            employees = _employeeRepository.GetSort(sortField, sortDirection, employees);

            var pagedEmployees = employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalEmployees / (double)pageSize);
            ViewBag.SortField = sortField;
            ViewBag.SortDirection = sortDirection;

            return View(pagedEmployees);
        }


        public IActionResult ExportToExcel(string sortField = "EmployeeId", string sortDirection = "asc")
        {
            var employees = _employeeRepository.GetEmployees().ToList();

            employees = _employeeRepository.GetSort(sortField, sortDirection, employees).ToList();

            // Create workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                // Add headers
                worksheet.Cell(1, 1).Value = "EmployeeId";
                worksheet.Cell(1, 2).Value = "EmployeeName";

                // Add data
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cell(i + 2, 1).Value = employee.EmployeeId;
                    worksheet.Cell(i + 2, 2).Value = employee.EmployeeName;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var fileName = "Employees.xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
    }
}
