namespace WMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.locations.ToListAsync();
        }

        public async Task<Location> Add(Location locationList)
        {
            var LocationId = string.IsNullOrEmpty(locationList.LocationId)
                ? Guid.NewGuid().ToString()
                : locationList.LocationId;

            var newLocation = new Location
            {
                LocationId = LocationId,
                ItemLots = locationList.ItemLots??new List<ItemLot>()
            };

            _context.locations.Add(newLocation);

            await _context.SaveChangesAsync();

            return locationList;
        }


    }
}
