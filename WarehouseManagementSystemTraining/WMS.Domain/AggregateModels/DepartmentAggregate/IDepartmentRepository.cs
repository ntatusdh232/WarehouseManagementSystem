using DocumentFormat.OpenXml.Bibliography;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.DepartmentAggregate
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Department>> GetAllAsync();
        Task Add(Department request, CancellationToken cancellationToken);
        Task<Department> GetDepartmentById(string departmentId);
        Task<Department> AdDepartment(Department request, CancellationToken cancellationToken);
    }
}
