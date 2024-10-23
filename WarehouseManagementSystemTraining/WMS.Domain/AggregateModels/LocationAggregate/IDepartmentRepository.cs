namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location> Add(Location warehouseList);
    }
}
