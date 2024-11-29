namespace WMS.Infrastructure.Repositories
{
    public class ItemLotLocationRepository : BaseRepository, IItemLotLocationRepository
    {
        public ItemLotLocationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Location>> GetByIdAsync(string lotId)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            var locationlist = existingItemLot.Locations;

            return locationlist;

        }

        public async Task<Location> AddAsync(string lotId, Location location)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            existingItemLot.Locations.Add(location);

            await _context.SaveChangesAsync();

            return location;

        }

        public async Task<Location> Update(string lotId, Location location)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            var existingLocation = existingItemLot.Locations.FirstOrDefault(x => x.LocationId == location.LocationId);

            existingLocation.LocationUpdate(location.LocationId, location.ItemLots);

            await _context.SaveChangesAsync();

            return existingLocation;

        }

        public async Task Remove(string lotId, string locationId)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            var existingLocation = existingItemLot.Locations.FirstOrDefault(x => x.LocationId == locationId);

            existingItemLot.Locations.Remove(existingLocation);

            await _context.SaveChangesAsync();

        }

    }
}
