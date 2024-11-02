using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemLotLocationRepository : IRepository<ItemLotLocation>
    {
        // Hiển thị Location
        Task <IEnumerable<Location>> GetByIdAsync(string lotId);
        Task <Location> AddAsync(string lotId, Location location);
        Task <Location> Update(string lotId, Location location);
        Task Remove(string lotId, string locationId);

    }
}
