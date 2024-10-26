using WMS.Domain.AggregateModels.WarehouseAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IDepartmentRepository : IRepository<Warehouse>
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task Add(Warehouse request, CancellationToken cancellationToken);
        Task<Warehouse> GetWarehouseById(string warehouseId);
        Task<Warehouse> AdDepartment(Warehouse request, CancellationToken cancellationToken);
    }
}
