using WMS.Domain.AggregateModels.DepartmentAggregate;
using WMS.Domain.AggregateModels.StorageAggregate;

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
        public async Task<IActionResult> Add([FromBody] Department department, CancellationToken cancellationToken)
        {
            if (department == null)
                return BadRequest("Warehouse data is required.");

            try
            {
                var addedDepartment = _departmentRepository.Add(department);
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
