using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IStorageRepository : IRepository<Location>
    {
        Task<Warehouse> Add(Warehouse warehouse);
        Task <IEnumerable<Warehouse>> GetALL();
        Task<Location> GetLocationsById(string locationId);
        Task<IEnumerable<Warehouse>> GetWarehousesById(string warehouseId); 
    }
}
