using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace ImportData.Repositories
{
    public class ItemLotLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemLotLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ItemLotLocation GetItemById(string itemLotLocaionId)
        {
            return _context.itemLotLocations.AsNoTracking().FirstOrDefault(i => i.ItemLotLocationId == itemLotLocaionId);
        }

        public void AddItem(ItemLotLocation itemLotLocaion)
        {
            _context.itemLotLocations.Add(itemLotLocaion);
        }

        public void UpdateItem(ItemLotLocation itemLotLocaion)
        {
            _context.itemLotLocations.Update(itemLotLocaion);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ItemLotLocation GetItemLotLocationByLotAndLocation(string lotId, string locationId)
        {
            return _context.itemLotLocations
                .FirstOrDefault(x => x.LotId == lotId && x.LocationId == locationId);
        }

    }
}
