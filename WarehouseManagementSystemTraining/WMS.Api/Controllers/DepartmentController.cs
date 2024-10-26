namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        private IActionResult HandleInternalError(Exception ex) => StatusCode(500, $"Internal server error: {ex.Message}");

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(departments);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Warehouse department, CancellationToken cancellationToken)
        {
            if (department == null)
                return BadRequest("Department data is required.");

            try
            {
                var addedDepartment = await _departmentRepository.AdDepartment(department, cancellationToken);
                return CreatedAtAction(nameof(GetAll), addedDepartment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return HandleInternalError(ex);
            }
        }

    }
}
