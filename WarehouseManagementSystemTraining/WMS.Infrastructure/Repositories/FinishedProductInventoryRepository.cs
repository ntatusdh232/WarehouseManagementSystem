namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductInventoryRepository : BaseRepository, IFinishedProductInventoryRepository
    {
        public FinishedProductInventoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<FinishedProductInventory> Add(FinishedProductInventory finishedProductInventory)
        {
            
            // Kiểm tra Id có tồn tại trong SQL chưa, nếu có báo lỗi
            var existingItem = await _context.finishedProductInventories.FindAsync(finishedProductInventory.FinishedProductInventoryId);
            if (existingItem != null)
            {
                throw new ArgumentException($"Item with ID {finishedProductInventory.FinishedProductInventoryId} already exists.");
            }
            
            await _context.finishedProductInventories.AddAsync(finishedProductInventory);
            await _context.SaveChangesAsync();
            return finishedProductInventory;
        }

        public async Task<IEnumerable<FinishedProductInventory>> GetAllFinishedProductInventory()
        {
            var finishedProductInventories = await _context.finishedProductInventories
                .ToListAsync();

            return finishedProductInventories;
        }

        public async Task Remove(string finishedProductInventoryId)
        {
            var finishedProductInventory = await _context.finishedProductInventories.FindAsync(finishedProductInventoryId);
            if (finishedProductInventory == null)
            {
                throw new KeyNotFoundException();
            }

            _context.finishedProductInventories.Remove(finishedProductInventory);
            await _context.SaveChangesAsync();
        }

        public async Task<FinishedProductInventory> Update(FinishedProductInventory finishedProductInventory)
        {
            var existingItem = await _context.Set<FinishedProductInventory>().FindAsync(finishedProductInventory.FinishedProductInventoryId);

            if (existingItem == null)
            {
                throw new KeyNotFoundException($"FinishedProductInventory with ID {finishedProductInventory.FinishedProductInventoryId} not found.");
            }
            existingItem.UpdateFinishedProductInventory(finishedProductInventory.PurchaseOrderNumber, finishedProductInventory.Quantity, finishedProductInventory.Timestamp, finishedProductInventory.Item);

            await _context.SaveChangesAsync();

            return existingItem;
        }




    }
}
