using WMS.Api.Application.Commands.Warehouses;

namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<LocationViewModel>> GetAll()
        {
            var query = new GetAllLocationsQuery();

            return await _mediator.Send(query);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateLocationCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);

        }

    }
}
