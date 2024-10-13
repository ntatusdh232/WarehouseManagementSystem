namespace WMS.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        private List<ItemList> _itemlist { get; set; }

        public ItemRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ItemList>> GetItemLists()
        {
            var itemlist = await _context.items
                .Select(x => new ItemList
                {
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    ItemType = x.ItemType,
                    MinimumStockLevel = x.MinimumStockLevel,
                    PacketSize = x.PacketSize,
                    PacketUnit = x.PacketUnit,
                    Price = x.Price,
                    Unit = x.Unit
                }).ToListAsync();
            
            
            return itemlist;
        }

        public async Task<ItemList> GetItemId(string itemId)
        {
            var item = await _context.items
                .Where(x => x.ItemId == itemId)
                .Select(x => new ItemList
                {
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    ItemType = x.ItemType,
                    MinimumStockLevel = x.MinimumStockLevel,
                    PacketSize = x.PacketSize,
                    PacketUnit = x.PacketUnit,
                    Price = x.Price,
                    Unit = x.Unit
                })
                .FirstOrDefaultAsync();

            return item;
        }

        public IEnumerable<ItemList> GetItems()
        {
            return _context.items
                .Select(x => new ItemList
                {
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    ItemType = x.ItemType,
                    MinimumStockLevel = x.MinimumStockLevel,
                    PacketSize = x.PacketSize,
                    PacketUnit = x.PacketUnit,
                    Price = x.Price,
                    Unit = x.Unit
                })
                .ToList();
        }

        


    }
}
