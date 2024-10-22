namespace WMS.Infrastructure.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task <Item> Add(Item item)
        {
            var existingItem = await _context.items.FindAsync(item.ItemId);

            if (existingItem != null)
            {
                throw new ArgumentException($"Item with ID {item.ItemId} already exists.");
            }

            await _context.items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> GetItemByEntityId(string entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItemsByItemClass(string itemClassId)
        {
            var items = await _context.Set<Item>()
                .Where(ic => ic.ItemClasses.Any(s => s.ItemClassId == itemClassId))
                .ToListAsync();

            return items;
        }

        public async Task <ItemList> Update(ItemList itemList)
        {

            var existingItem = await _context.items.FindAsync(itemList.ItemId);

            if (existingItem != null)
            {
                existingItem.Update(itemList.Unit, itemList.MinimumStockLevel, itemList.Price);

                await _context.SaveChangesAsync();

                return itemList;
            }
            else
            {

                throw new KeyNotFoundException($"Item with ID {itemList.ItemId} not found.");
            }
        }


        public async Task<IEnumerable<Item>> GetItemById(string itemId)
        {
            var item = await _context.items.FindAsync(itemId);

            if (item == null)
            {
                throw new KeyNotFoundException($"Item with ID {itemId} not found.");
            }

            return new List<Item> { item };

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

        public IEnumerable<ItemList> GetSort(string sortField, string sortDirection, IEnumerable<ItemList> items)
        {
            switch (sortField)
            {
                case "ItemId":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemId).ToList()
                        : items.OrderBy(i => i.ItemId).ToList();
                    break;

                case "ItemName":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemName).ToList()
                        : items.OrderBy(i => i.ItemName).ToList();
                    break;

                case "ItemType":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemType).ToList()
                        : items.OrderBy(i => i.ItemType).ToList();
                    break;
                case "MinimumStockLevel":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.MinimumStockLevel).ToList()
                        : items.OrderBy(i => i.MinimumStockLevel).ToList();
                    break;
                case "PacketSize":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.PacketSize).ToList()
                        : items.OrderBy(i => i.PacketSize).ToList();
                    break;
                case "PacketUnit":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.PacketUnit).ToList()
                        : items.OrderBy(i => i.PacketUnit).ToList();
                    break;
                case "Price":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.Price).ToList()
                        : items.OrderBy(i => i.Price).ToList();
                    break;
                case "Unit":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.Unit).ToList()
                        : items.OrderBy(i => i.Unit).ToList();
                    break;
                default:
                    items = items.OrderBy(i => i.ItemId).ToList();
                    break;
            }

            return items;
        }

        public IXLWorksheet? GetItemListworksheet(IEnumerable<ItemList> items, IXLWorksheet? worksheet)
        {

            worksheet.Cell(1, 1).Value = "ID Item";
            worksheet.Cell(1, 2).Value = "Tên Item";
            worksheet.Cell(1, 3).Value = "Loại Item";
            worksheet.Cell(1, 4).Value = "Mức tồn kho tối thiểu";
            worksheet.Cell(1, 5).Value = "Kích thước gói";
            worksheet.Cell(1, 6).Value = "Đơn vị gói";
            worksheet.Cell(1, 7).Value = "Giá";
            worksheet.Cell(1, 8).Value = "Đơn vị";

            for (int i = 0; i < items.Count(); i++)
            {
                var item = items.ElementAt(i);
                worksheet.Cell(i + 2, 1).Value = item.ItemId;
                worksheet.Cell(i + 2, 2).Value = item.ItemName;
                worksheet.Cell(i + 2, 3).Value = item.ItemType;
                worksheet.Cell(i + 2, 4).Value = item.MinimumStockLevel;
                worksheet.Cell(i + 2, 5).Value = item.PacketSize;
                worksheet.Cell(i + 2, 6).Value = item.PacketUnit;
                worksheet.Cell(i + 2, 7).Value = item.Price;
                worksheet.Cell(i + 2, 8).Value = item.Unit;
            }

            return worksheet;
        }

        public async Task<Item> AddItem(Item item)
        {        
            try
            {
                _context.items.Add(item); 
                await _context.SaveChangesAsync(); 
                return item;
            }
            catch (Exception ex)
            {
                
                throw new InvalidOperationException("Không thể thêm vật phẩm vào cơ sở dữ liệu: " + ex.Message);
            }
        }

        public List<ItemList> GetPageItems(IEnumerable<ItemList> items, int pageNumber, int pageSize)
        {
            var pagedItems = items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedItems;
        }

        public async Task UpdateItem(ItemList item)
        {
            var existingItem = await _context.items.FindAsync(item.ItemId);
            if (existingItem != null)
            {
                existingItem.ItemName = item.ItemName;
                existingItem.ItemType = item.ItemType;
                existingItem.MinimumStockLevel = item.MinimumStockLevel;
                existingItem.PacketSize = item.PacketSize;
                existingItem.PacketUnit = item.PacketUnit;
                existingItem.Price = item.Price;
                existingItem.Unit = item.Unit;

                _context.items.Update(existingItem);
                await _context.SaveChangesAsync();
            }
        }




    }
}
