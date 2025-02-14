﻿namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductInventoryRepository : BaseRepository, IFinishedProductInventoryRepository
    {
        public FinishedProductInventoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<FinishedProductInventory> Add(FinishedProductInventory finishedProductInventory)
        {
            
            var existingItem = await _context.finishedProductInventories.FindAsync(finishedProductInventory.FinishedProductInventoryId);          
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
            _context.finishedProductInventories.Remove(finishedProductInventory);
            await _context.SaveChangesAsync();
        }

        public async Task<FinishedProductInventory> Update(FinishedProductInventory finishedProductInventory)
        {
            var existingItem = await _context.Set<FinishedProductInventory>().FindAsync(finishedProductInventory.FinishedProductInventoryId);

            existingItem.UpdateFinishedProductInventory(finishedProductInventory.PurchaseOrderNumber, finishedProductInventory.Quantity, finishedProductInventory.Timestamp, finishedProductInventory.Item);

            await _context.SaveChangesAsync();

            return existingItem;
        }

        public async Task<IEnumerable<FinishedProductInventory>> GetProductInventoriesByItemId(string itemId, CancellationToken cancellationToken)
        {
            var productInverotyList = await _context.finishedProductInventories.Where(s => s.ItemId == itemId).ToListAsync(cancellationToken);

            return productInverotyList;
        }

        public async Task<IEnumerable<string>> GetPos()
        {
            var POsList = await _context.finishedProductInventories.Select(s => s.PurchaseOrderNumber).ToListAsync();
            return POsList;
        }

        public async Task<FinishedProductInventory?> GetInventory(string itemId, string unit, string purchaseOrderNumber)
        {
            var Inventory = await _context.finishedProductInventories
                .FirstOrDefaultAsync(s => s.ItemId == itemId && s.PurchaseOrderNumber == purchaseOrderNumber && s.Item.Unit == unit);

            return Inventory;


        }

        public async Task Update(FinishedProductReceiptEntry Entry)
        {

            var existingItem = await _context.finishedProductInventories.FindAsync(Entry.ItemId);
            if (existingItem != null)
            {
                existingItem.UpdateFinishedProductInventory(Entry.PurchaseOrderNumber, Entry.Quantity, DateTime.Now, Entry.Item);

            }

        }

    }
}
