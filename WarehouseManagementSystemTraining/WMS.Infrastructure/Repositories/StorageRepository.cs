﻿using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.Repositories
{
    public class StorageRepository : BaseRepository, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Location> AddLocation(Location location)
        {
            var existingLocation = await _context.locations.FirstOrDefaultAsync(s => s.LocationId == location.LocationId);

            await _context.locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Warehouse> AddWarehouse(Warehouse warehouse)
        {
            var existingWarehouse = await _context.warehouses.FindAsync(warehouse.WarehouseId);

            await _context.warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<IEnumerable<Warehouse>> GetALL()
        {
            var warehouseList = await _context.warehouses.ToListAsync();
            return warehouseList;
        }

        public async Task<Location> GetLocationById(string locationId)
        {
            var location = await _context.locations.FindAsync(locationId);

            return location;
        }
        public async Task<IEnumerable<Location>> GetLocationsById(string locationId)
        {
            var locationList = await _context.locations.Where(x => x.LocationId == locationId).ToListAsync();
            return locationList;
        }

        public async Task<Warehouse> GetWarehouseById(string warehouseId)
        {
            var warehouse = await _context.warehouses.FindAsync(warehouseId);

            return warehouse;
        }

        public async Task<IEnumerable<Warehouse>> GetWarehousesById(string warehouseId)
        {
            var warehouseList = await _context.warehouses.Where(x => x.WarehouseId == warehouseId).ToListAsync();
            return warehouseList;
        }
    }
}
