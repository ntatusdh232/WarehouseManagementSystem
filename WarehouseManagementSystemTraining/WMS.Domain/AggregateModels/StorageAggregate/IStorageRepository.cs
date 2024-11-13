using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IStorageRepository : IRepository<Location>
    {
        Task<Warehouse> AddWarehouse(Warehouse warehouse);
        Task<Location> AddLocation(Location warehouse);
        Task<IEnumerable<Warehouse>> GetALL();
        Task<IEnumerable<Location>> GetLocationsById(string locationId);
        Task<Location> GetLocationById(string locationId);
        Task<IEnumerable<Warehouse>> GetWarehousesById(string warehouseId);
        Task<Warehouse> GetWarehouseById(string warehouseId);
    }
}
