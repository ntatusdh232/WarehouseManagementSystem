namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository; // Sử dụng IItemRepository thay vì ItemRepository

        public ItemController(IItemRepository itemRepository) // Sửa tham số vào constructor
        {
            _itemRepository = itemRepository;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IEnumerable<ItemList>> GetAllItem()
        {
            return await _itemRepository.GetItemLists();
        }

        [HttpGet("{itemId}")]
        public async Task<ItemList> GetItemId(string itemId)
        {
            return await _itemRepository.GetItemId(itemId);
        }
    }
}
