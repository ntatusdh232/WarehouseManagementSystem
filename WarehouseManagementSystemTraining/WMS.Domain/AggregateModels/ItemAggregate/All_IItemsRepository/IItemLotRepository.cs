namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemLotRepository : IRepository<ItemLot>
    {
        Task<ItemLot> AddLot(ItemLot itemLot);
        Task<ItemLot> AddLots(ItemLot itemLot);
        Task<ItemLot> UpdateLot(string LotId, ItemLot itemLot);
        Task<ItemLot> UpdateLots(string LotId, ItemLot itemLot);
        Task DeleteLot(string LotId);
        Task DeleteLots(string LotId);
        Task<IEnumerable<ItemLot>> GetLotByLotId(string LotId);
        Task<IEnumerable<ItemLot>> GetLotsByItemId(string ItemId);
        Task<IEnumerable<ItemLot>> GetIsolatedItemLots();

    }
}
