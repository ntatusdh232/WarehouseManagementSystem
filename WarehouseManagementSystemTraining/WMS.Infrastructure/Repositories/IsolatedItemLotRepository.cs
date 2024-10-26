using DocumentFormat.OpenXml.InkML;

namespace WMS.Infrastructure.Repositories
{
    public class IsolatedItemLotRepository : BaseRepository, IIsolatedItemLotRepository
    {
        public IsolatedItemLotRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ItemLot> AddAsync(ItemLot itemLot)
        {
            var exitingItem = await _context.itemsLot.FindAsync(itemLot.LotId);

            if (exitingItem != null)
            {
                throw new ArgumentException($"ItemLot with ID {itemLot.LotId} already exists.");
            }

            await _context.itemsLot.AddAsync(itemLot);
            await _context.SaveChangesAsync();

            return itemLot;

        }

        public async Task<ItemLot> Update(ItemLot itemLot)
        {
            var existingItem = await _context.itemsLot.FindAsync(itemLot.LotId);

            if (existingItem == null)
            {
                throw new ArgumentException($"ItemLot with ID {itemLot.LotId} does not exist.");
            }

            if (existingItem.IsIsolated == false)
            {
                throw new ArgumentException($"ItemLot with ID {itemLot.LotId} is not isolated.");
            }

            existingItem.Update(itemLot.Quantity, itemLot.Timestamp, itemLot.ProductionDate, itemLot.ExpirationDate);

            await _context.SaveChangesAsync();
            return existingItem;

        }

        public async Task Remove(string lotId)
        {
            var existingItem = await _context.itemsLot.FindAsync(lotId);
            if (existingItem == null)
            {
                throw new ArgumentException($"ItemLot with ID {lotId} does not exist.");
            }

            if (existingItem.IsIsolated == false)
            {
                throw new ArgumentException($"ItemLot with ID {lotId} is not isolated.");
            }

            _context.itemsLot.Remove(existingItem);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ItemLot>> GetAsync()
        {
            var ItemLotList = await _context.itemsLot.Where(s => s.IsIsolated == true).ToListAsync();

            if (ItemLotList == null)
            {
                throw new ArgumentException("No isolated ItemLot found.");
            }

            return ItemLotList;

        }


    }
}
