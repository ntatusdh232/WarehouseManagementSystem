using WMS.Domain.AggregateModels.InventoryLogEntryAggregate;

namespace ImportData.Repositories
{
    public class InventoryLogEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryLogEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public InventoryLogEntry GetItemById(string id)
        {
            return _context.inventoryLogEntries.AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(InventoryLogEntry inventoryLogEntry)
        {
            _context.inventoryLogEntries.Add(inventoryLogEntry);
        }

        public void UpdateItem(InventoryLogEntry itemLotLocaion)
        {
            _context.inventoryLogEntries.Update(itemLotLocaion);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public InventoryLogEntry GetInventoryLogEntryByLotAndItem(string itemId, string itemlotId)
        {
            return _context.inventoryLogEntries
                .FirstOrDefault(x => x.ItemId == itemId && x.ItemLotId == itemlotId);
        }
    }
}
