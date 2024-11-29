using WMS.Api.Application.Commands.GoodsReceipts;
using WMS.Api.Application.Commands.IsolatedItemLots;
using WMS.Api.Application.Commands.ItemLots;

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
        public async Task<ItemLotViewModel> GetItemLotByLotId(string LotId)
        {
            var query = new GetItemLotByLotIdQuery(LotId);

            return await _mediator.Send(query);
        }

        [HttpGet("GetItemLotsByLocation/{LocationId}")]
        public async Task<IEnumerable<ItemLotViewModel>> GetItemLotsByLocation(string LocationId)
        {
            var query = new GetItemLotsByLocationQuery(LocationId);

            return await _mediator.Send(query);
        }

        [HttpGet("GetItemLots/{ItemId}")]
        public async Task<IEnumerable<ItemLotViewModel>> GetItemLots(string ItemId)
        {
            var query = new GetItemLotsQuery(ItemId);

            return await _mediator.Send(query);
        }

        [HttpPut("UnisolateItemLot - DO NOT TEST")]
        public async Task<IActionResult> UnisolateItemLot([FromBody] UnisolateItemLotCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("IsolateItemLot{id}")]
        public async Task<IActionResult> IsolateItemLot(string id, [FromBody] IsolateItemLotCommand request)
        {
            var command = new IsolateItemLotCommand(id, request.IsolatedItemSublots);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("RemoveItemLot {itemLotId}")]
        public async Task<IActionResult> RemoveItemLot(string itemLotId)
        {
            var command = new RemoveItemLotCommand(itemLotId);

            var result = await _mediator.Send(command);

            return Ok(result);
            
        }
    }
}
