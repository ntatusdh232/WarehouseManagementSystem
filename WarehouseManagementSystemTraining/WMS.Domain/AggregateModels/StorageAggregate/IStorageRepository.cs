using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IStorageRepository : IRepository<Department>, IRepository<Location>
    {
        Task<Department> Add(Department warehouse);
        Task <IEnumerable<Department>> GetALL();
        Task<IEnumerable<Location>> GetLocationsById(string locationId);
        Task<IEnumerable<Department>> GetWarehousesById(string warehouseId); 
    }
}
