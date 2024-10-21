using WMS.Domain.AggregateModels.WarehouseAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IStorageRepository : IRepository<Warehouse>, IRepository<Location>
    {
        Task<Warehouse> Add(Warehouse warehouse);
        Task <IEnumerable<Warehouse>> GetALL();
        Task<IEnumerable<Location>> GetLocationsById(string locationId);
        Task<IEnumerable<Warehouse>> GetWarehousesById(string warehouseId); 
    }
}
