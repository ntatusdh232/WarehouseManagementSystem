using WMS.Api.Application.Commands.Items;

namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        public ItemController(IItemRepository itemRepository, IMediator mediator)
        {
            _itemRepository = itemRepository;
            _mediator = mediator;
        }

        [HttpGet("GetAll - success")]
        public async Task<IEnumerable<string>> GetAllItems([FromQuery] string? itemClassId = null)
        {
            var query = new GetAllItemsAsyncQuery(itemClassId);
            return await _mediator.Send(query);
        }


        [HttpGet("GetItemById - success/{ItemId}")]
        public async Task<ItemViewModel> GetItemById(string ItemId, [FromQuery] string? Unit = null)
        {
            var query = new GetItemByIdAsyncQuery(ItemId, Unit);
            return await _mediator.Send(query);
        }

        // Post
        [HttpPost("Create - success")]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("CreateItems - success")]
        public async Task<IActionResult> CreateItems([FromBody] CreateItemsCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("Update - success")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }



        


    }
}
