namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IIsolatedItemLotRepository : IRepository<ItemLot>
    {
        Task <ItemLot> AddAsync(ItemLot itemLot);
        Task <ItemLot> Update(ItemLot itemLot);
        Task Remove(string lotId);
        Task<IEnumerable<ItemLot>> GetAsync();
    }
}
