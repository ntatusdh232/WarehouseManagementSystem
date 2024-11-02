using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.WarehouseAggregate
{
    public interface IDepartmentRepository : IRepository<Warehouse>
    {
        Task<IEnumerable<Warehouse>> GetAllDepartmentsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task Add(Warehouse request, CancellationToken cancellationToken);
        Task<Warehouse> GetWarehouseById(string departmentId);
        Task<Warehouse> AdDepartment(Warehouse request, CancellationToken cancellationToken);
    }
}
