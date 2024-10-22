namespace WMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.locations.ToListAsync();
        }

        public async Task<LocatonList> Add(LocatonList locationList)
        {
            var LocationId = string.IsNullOrEmpty(locationList.LocationId)
                ? Guid.NewGuid().ToString()
                : locationList.LocationId;

            var newLocation = new Location
            {
                LocationId = LocationId,
                WarehouseId = locationList.WarehouseId
            };

            _context.locations.Add(newLocation);

            await _context.SaveChangesAsync();

            return locationList;
        }


    }
}
