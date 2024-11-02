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

            if (existingItemLot == null)
            {
                throw new Exception("ItemLot does not exist");
            }

            var locationlist = existingItemLot.Locations;

            if (locationlist == null)
            {
                throw new Exception("ItemLot does not Locaiton");
            }

            return locationlist;

        }

        public async Task<Location> AddAsync(string lotId, Location location)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            if (existingItemLot == null)
            {
                throw new Exception("ItemLot does not exist");
            }

            if (location == null)
            {
                throw new Exception("Location is null");
            }

            existingItemLot.Locations.Add(location);
            await _context.SaveChangesAsync();

            return location;

        }

        public async Task<Location> Update(string lotId, Location location)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            if (existingItemLot == null)
            {
                throw new Exception("ItemLot does not exist");
            }

            var existingLocation = existingItemLot.Locations.FirstOrDefault(x => x.LocationId == location.LocationId);
            if (existingLocation == null)
            {
                throw new Exception("Location does not exist");
            }
            if (location == null)
            {
                throw new Exception("Location is null");
            }

            existingLocation.LocationUpdate(location.LocationId, location.ItemLots);

            await _context.SaveChangesAsync();

            return existingLocation;

        }

        public async Task Remove(string lotId, string locationId)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(lotId);

            if (existingItemLot == null)
            {
                throw new Exception("ItemLot does not exist");
            }

            var existingLocation = existingItemLot.Locations.FirstOrDefault(x => x.LocationId == locationId);
            if (existingLocation == null)
            {
                throw new Exception("Location does not exist");
            }

            existingItemLot.Locations.Remove(existingLocation);
            await _context.SaveChangesAsync();

        }

    }
}
