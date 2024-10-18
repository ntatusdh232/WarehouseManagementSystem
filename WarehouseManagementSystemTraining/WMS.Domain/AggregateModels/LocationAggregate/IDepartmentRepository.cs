namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<LocatonList> Add(LocatonList warehouseList);
    }
}
