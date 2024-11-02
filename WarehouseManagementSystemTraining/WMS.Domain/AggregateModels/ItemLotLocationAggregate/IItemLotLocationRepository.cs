namespace WMS.Domain.AggregateModels.ItemLotLocationAggregate
{
    internal interface IItemLotLocationRepository : IRepository<ItemLotLocation>
    {
        Task<ItemLotLocation?> GetByIdAsync(int itemLotId, int locationId);
        Task AddAsync(ItemLotLocation itemLotLocation);
        void Update(ItemLotLocation itemLotLocation);

    }
}
