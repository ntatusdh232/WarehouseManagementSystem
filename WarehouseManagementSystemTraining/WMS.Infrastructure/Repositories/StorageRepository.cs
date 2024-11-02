using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.Repositories
{
    internal class StorageRepository : BaseRepository, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Department> Add(Department warehouse)
        {
            var existingWarehouse = await _context.warehouses.FindAsync(warehouse.WarehouseId);
            if (existingWarehouse == warehouse)
            {
                throw new ArgumentException($"Department already exists.");
            }
            await _context.warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<IEnumerable<Department>> GetALL()
        {
            var warehouseList = await _context.warehouses.ToListAsync();
            return warehouseList;
        }

        public async Task<IEnumerable<Location>> GetLocationsById(string locationId)
        {
            var locationList = await _context.locations.Where(x => x.LocationId == locationId).ToListAsync();
            return locationList;
        }

        public async Task<IEnumerable<Department>> GetWarehousesById(string warehouseId)
        {
            var warehouseList = await _context.warehouses.Where(x => x.WarehouseId == warehouseId).ToListAsync();
            return warehouseList;
        }
    }
}
