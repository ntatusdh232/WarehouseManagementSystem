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

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ItemViewModel>> GetAllItems([FromQuery] string? itemClassId = null)
        {
            var query = new GetAllItemsAsyncQuery(itemClassId);
            return await _mediator.Send(query);
        }


        [HttpGet("GetItemById/{ItemId}")]
        public async Task<ItemViewModel> GetItemById(string ItemId, [FromQuery] string? Unit = null)
        {
            var query = new GetItemByIdAsyncQuery(ItemId, Unit);
            return await _mediator.Send(query);
        }


    }
}
