using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
