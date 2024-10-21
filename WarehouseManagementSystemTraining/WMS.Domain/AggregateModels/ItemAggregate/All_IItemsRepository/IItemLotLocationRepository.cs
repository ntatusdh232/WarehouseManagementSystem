namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemLotLocationRepository : IRepository<ItemLot>, IRepository<Location>
    {
        // Hiển thị Location
        Task <IEnumerable<Location>> GetByIdAsync(string lotId);
        Task <Location> AddAsync(string lotId, Location location);
        Task <Location> Update(string lotId, string locationId, Location location);
        Task Remove(string lotId, string locationId);

    }
}
