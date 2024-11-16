namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public EmployeeController(IEmployeeRepository employeeRepository, IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        private IActionResult HandleInternalError(Exception ex) => StatusCode(500, $"Internal server error: {ex.Message}");

        [HttpGet("Employee/GetAllEmployees")]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeeALl()
        {
            var query = new GetAllEmployeeQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("Employee/GetEmployeeById/{EmployeeId}")]
        public async Task<EmployeeViewModel> GetEmployeeById(string EmployeeId)
        {
            var query = new GetEmployeeByIdQuery(EmployeeId);
            return await _mediator.Send(query);
        }



        //[HttpGet("Employee/GetEmployByid/{employeeId}")]
        //public async Task<Employee> GetEmployeeId(string employeeId)
        //{
        //    return await _employeeRepository.GetEmployeeById(employeeId);
        //}

        //[HttpGet("Employee/GetEmployeeByName/{employeeName}")]
        //public async Task<Employee> GetEmployeeName(string employeeName)
        //{
        //    return await _employeeRepository.GetEmployeeByName(employeeName);
        //}

        //// POST: api/Employee
        //[HttpPost("Employee/AddEmployee")]
        //public async Task<IActionResult> AddEmployee([FromBody] Employee employeeList)
        //{
        //    try
        //    {
        //        // Kiểm tra nếu employeeList là null
        //        if (employeeList == null)
        //        {
        //            return BadRequest("Employee data is required.");
        //        }

        //        var addedEmployee = await _employeeRepository.Add(employeeList);

        //        return Ok(addedEmployee);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý các lỗi khác
        //        return HandleInternalError(ex);
        //    }
        //}

        //// PUT: api/Employee/{employeeId}
        //[HttpPut("Employee/UpdateEmployee/{employeeId}")]
        //public async Task<IActionResult> UpdateEmployee(string employeeId, [FromBody] Employee updatedEmployee)
        //{
        //    try
        //    {
        //        // Kiểm tra nếu đối tượng đầu vào không hợp lệ
        //        if (updatedEmployee == null || updatedEmployee.EmployeeId != employeeId)
        //        {
        //            return BadRequest("Invalid employee data or mismatched ID.");
        //        }

        //        var employee = await _employeeRepository.Update(updatedEmployee);

        //        if (employee == null)
        //        {
        //            return NotFound($"Employee with ID {employeeId} not found.");
        //        }

        //        return Ok(employee); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleInternalError(ex);
        //    }
        //}


    }
}
