using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMediator _mediator;

        public DepartmentController(IDepartmentRepository departmentRepository, IMediator mediator)
        {
            _departmentRepository = departmentRepository;
            _mediator = mediator;
        }

        private IActionResult HandleInternalError(Exception ex) => StatusCode(500, $"Internal server error: {ex.Message}");

        [HttpGet("Department/GetAll")]
        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            var query = new GetAllDepartmentsQuery();

            return await _mediator.Send(query);
        }

        //[HttpPost("Add")]
        //public async Task<IActionResult> Add([FromBody] Department department, CancellationToken cancellationToken)
        //{
        //    if (department == null)
        //        return BadRequest("Warehouse data is required.");

        //    try
        //    {
        //        var addedDepartment = _departmentRepository.Add(department);
        //        return CreatedAtAction(nameof(GetAll), addedDepartment);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleInternalError(ex);
        //    }
        //}

    }
}
