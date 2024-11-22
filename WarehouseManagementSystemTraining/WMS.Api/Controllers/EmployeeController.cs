namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
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

        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeeALl()
        {
            var query = new GetAllEmployeeQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("GetEmployeeById/{EmployeeId}")]
        public async Task<EmployeeViewModel> GetEmployeeById(string EmployeeId)
        {
            var query = new GetEmployeeByIdQuery(EmployeeId);
            return await _mediator.Send(query);
        }



    }
}
