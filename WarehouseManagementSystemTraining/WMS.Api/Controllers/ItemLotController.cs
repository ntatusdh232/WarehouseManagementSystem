namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemLotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemLotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ItemLotViewModel>> GetAll()
        {
            var query = new Application.Queries.ItemLots.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetIsolatedItemLots")]
        public async Task<IEnumerable<ItemLotViewModel>> GetIsolatedItemLots([FromQuery] bool isIsolated)
        {
            var query = new GetIsolatedItemLotsQuery(isIsolated);

            return await _mediator.Send(query);
        }

        [HttpGet("GetItemLotByLotId/{LotId}")]
        public async Task<ItemLotViewModel> GetItemLotByLotId(string lotId)
        {
            var query = new GetItemLotByLotIdQuery(lotId);

            return await _mediator.Send(query);
        }

        [HttpGet("GetItemLotsByLocation/{LocationId}")]
        public async Task<IEnumerable<ItemLotViewModel>> GetItemLotsByLocation(string locationId)
        {
            var query = new GetItemLotsByLocationQuery(locationId);

            return await _mediator.Send(query);
        }

        [HttpGet("GetItemLots/{ItemId}")]
        public async Task<IEnumerable<ItemLotViewModel>> GetItemLots(string itemId)
        {
            var query = new GetItemLotsQuery(itemId);

            return await _mediator.Send(query);
        }
    }
}
