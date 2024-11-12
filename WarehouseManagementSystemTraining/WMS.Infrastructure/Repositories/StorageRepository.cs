using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.Repositories
{
    internal class StorageRepository : BaseRepository, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Warehouse> Add(Warehouse warehouse)
        {
            var existingWarehouse = await _context.warehouses.FindAsync(warehouse.WarehouseId);
            if (existingWarehouse == warehouse)
            {
                throw new ArgumentException($"Warehouse already exists.");
            }
            await _context.warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<IEnumerable<Warehouse>> GetALL()
        {
            var warehouseList = await _context.warehouses.ToListAsync();
            return warehouseList;
        }

        public async Task<Location> GetLocationsById(string locationId)
        {
            var location = await _context.locations.FindAsync(locationId);
            if (location is null)
            {
                throw new Exception("Not Found");
            }

            return location;
        }

        public async Task<IEnumerable<Warehouse>> GetWarehousesById(string warehouseId)
        {
            var warehouseList = await _context.warehouses.Where(x => x.WarehouseId == warehouseId).ToListAsync();
            return warehouseList;
        }
    }
}
