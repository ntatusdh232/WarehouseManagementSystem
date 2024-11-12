namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemLotRepository : IRepository<ItemLot>
    {
        Task<ItemLot> AddLot(ItemLot itemLot);
        Task<IEnumerable<ItemLot>> AddLots(IEnumerable<ItemLot> itemLots);
        Task<ItemLot> UpdateLot(ItemLot itemLot);
        Task<IEnumerable<ItemLot>> UpdateLots(IEnumerable<ItemLot> updatedItemLots);
        Task Remove(string lotId);
        Task DeleteLots(string lotId);
        Task<ItemLot> GetItemLotById(string lotId);
        Task<IEnumerable<ItemLot>> GetLotsByItemId(string itemId);
        Task<IEnumerable<ItemLot>> GetIsolatedItemLots();

    }
}
