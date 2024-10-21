namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemLotLocationRepository : IRepository<ItemLot>, IRepository<Location>
    {
        Task <IEnumerable<Location>> GetByIdAsync(string lotId, string locationId);
        Task <ItemLot> AddAsync(string lotId, Location location);
        Task <Location> Update(string lotId, string locationId, Location location);
        Task Remove(string lotId, string locationId);

    }
}
