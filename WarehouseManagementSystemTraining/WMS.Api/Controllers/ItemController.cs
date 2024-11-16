namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
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


        [HttpGet("{ItemId}")]
        public async Task<ItemViewModel> GetItemById(string ItemId, [FromQuery] string? Unit = null)
        {
            var query = new GetItemByIdAsyncQuery(ItemId, Unit);
            return await _mediator.Send(query);
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        //{
        //    var items = await _itemRepository.GetItemLists();
        //    return Ok(items);
        //}

        //[HttpGet("GetByClassId/{itemClassId}")]
        //public async Task<IActionResult> GetByClassId(string itemClassId)
        //{
        //    var items = await _itemRepository.GetItemsByItemClass(itemClassId);
        //    if (items == null || !items.Any())
        //        return NotFound($"No items found for ItemClassId: {itemClassId}");

        //    return Ok(items);
        //}

        //[HttpPost("Add")]
        //public async Task<IActionResult> Add([FromBody] Item item)
        //{
        //    if (item == null)
        //        return BadRequest("Item data is required.");

        //    var addedItem = await _itemRepository.AddItem(item);
        //    return CreatedAtAction(nameof(GetItemById), new { itemId = addedItem.ItemId }, addedItem);
        //}

        //[HttpPut("Update/{itemId}")]
        //public async Task<IActionResult> Update(string itemId, [FromBody] Item updatedItem)
        //{
        //    if (updatedItem == null)
        //        return BadRequest("Item data is required.");

        //    var existingItem = await _itemRepository.GetItemById(itemId);
        //    if (existingItem == null)
        //        return NotFound($"Item with ID {itemId} not found.");

        //    var updated = await _itemRepository.Update(updatedItem);
        //    return Ok(updated);
        //}

    }
}
