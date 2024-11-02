using DocumentFormat.OpenXml.Bibliography;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.DepartmentAggregate
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Department Add(Department department);
    }
}
