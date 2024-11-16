namespace WMS.Domain.AggregateModels.DepartmentAggregate
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<List<Department>> GetAllAsync();
        Department Add(Department department);
    }
}
