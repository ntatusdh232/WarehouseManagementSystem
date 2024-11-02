using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.WarehouseAggregate
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Department>> GetAllAsync();
        Task Add(Department request, CancellationToken cancellationToken);
        Task<Department> GetWarehouseById(string departmentId);
        Task<Department> AdDepartment(Department request, CancellationToken cancellationToken);
    }
}
