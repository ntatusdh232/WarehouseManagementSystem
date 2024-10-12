namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeList>> GetEmployeeALl()
        {
            return await _employeeRepository.GetEmployeeLists();
        }

        [HttpGet("{employeeId}")]
        public async Task<EmployeeList> GetEmployeeId(string employeeId)
        {
            return await _employeeRepository.GetEmployeeId(employeeId);
        }
    }
}
