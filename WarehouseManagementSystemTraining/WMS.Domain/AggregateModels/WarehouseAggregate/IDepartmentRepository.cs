namespace WMS.Domain.AggregateModels.WarehouseAggregate
{
    public interface IDepartmentRepository : IRepository<Warehouse>
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task Add(Warehouse request, CancellationToken cancellationToken);
        Task<Warehouse> GetWarehouseById(string warehouseId);
        Task<Warehouse> AdDepartment(Warehouse request, CancellationToken cancellationToken);
    }
}
