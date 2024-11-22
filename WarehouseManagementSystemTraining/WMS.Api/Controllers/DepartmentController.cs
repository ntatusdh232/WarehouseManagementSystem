namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
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

        [HttpGet("GetAll")]
        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            var query = new GetAllDepartmentsQuery();

            return await _mediator.Send(query);
        }


    }
}
