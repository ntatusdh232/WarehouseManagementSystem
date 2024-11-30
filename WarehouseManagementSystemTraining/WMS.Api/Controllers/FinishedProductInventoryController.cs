namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class FinishedProductInventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinishedProductInventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPOs - success")]
        public async Task<IEnumerable<string>> GetPOs()
        {
            var query = new GetPOsQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetProductInventoriesByItemId - success/{Id}")]
        public async Task<IEnumerable<FinishedProductInventoryViewModel>> GetProductInventoriesByItemId(string Id)
        {
            var query = new GetProductInventoriesByItemIdQuery(Id);

            return await _mediator.Send(query);
        }

    }
}
