using System.Collections.Generic;
using WMS.Domain.SeedWork;

namespace WMS.View.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Phương thức Employee
        public async Task<IActionResult> Employee(string sortField = "EmployeeId", string sortDirection = "asc", 
                                                  int pageNumber = 1, int pageSize = 10)
        {
            var employees = _employeeRepository.GetEmployees();

            var totalEmployees = employees.Count();

            employees = _employeeRepository.GetSort(sortField, sortDirection, employees);

            // Phân trang
            var pagedEmployees = _employeeRepository.GetPageEmployees(employees, pageNumber, pageSize);

            // Tính tổng số trang
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalEmployees / (double)pageSize);
            ViewBag.SortField = sortField;
            ViewBag.SortDirection = sortDirection;

            return View(pagedEmployees); // Trả về danh sách nhân viên
        }

        public IActionResult ExportToExcel(string sortField = "EmployeeId", string sortDirection = "asc")
        {
            var employees = _employeeRepository.GetEmployees().ToList();

            employees = _employeeRepository.GetSort(sortField, sortDirection, employees).ToList();

            // Create workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                worksheet = _employeeRepository.GetEmployeeworksheet(employees, worksheet);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var fileName = "Employees.xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        public IActionResult Create()
        {
            return View("CreateEmployee");
        }

        // Phương thức SearchByEmployeeId
        public async Task<IActionResult> SearchAndEditByEmployeeId(string employeeId, string action1)
        {
            // Kiểm tra xem ID nhân viên có được cung cấp không
            if (string.IsNullOrEmpty(employeeId))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập ID nhân viên.";
                return RedirectToAction("Employee");
            }

            // Lấy thông tin nhân viên từ repository
            var employee = await _employeeRepository.GetEmployeeId(employeeId);

            if (action1 == "SearchEmployee") return View("EmployeeDetails", employee);
            if (action1 == "EditEmployee") return View("EditEmployee", employee);

            TempData["ErrorMessage"] = "Hành động không hợp lệ.";
            return RedirectToAction("Employee");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            // Xóa lỗi nếu GoodsReceiptLot không bắt buộc
            ModelState.Remove("GoodsReceiptLot");
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    await _employeeRepository.AddEmployee(employee);
                    await _unitOfWork.CommitTransactionAsync();

                    TempData["SuccessMessage"] = "Nhân viên đã được lưu thành công!";
                    return RedirectToAction("Employee");
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
                    }

                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }


            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(EmployeeList employee)
        {
            ModelState.Remove("GoodsReceiptLot");
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    // Gọi repository để cập nhật thông tin nhân viên
                    await _employeeRepository.UpdateEmployee(employee);
                    // Lưu thay đổi
                    await _unitOfWork.CommitTransactionAsync();

                    TempData["SuccessMessage"] = "Thông tin nhân viên đã được cập nhật thành công!";
                    return RedirectToAction("Employee");
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
                    }

                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }
            }

            // Nếu có lỗi, trở về view với thông tin nhân viên
            return View("EditEmployee", employee);
        }

    }
}
