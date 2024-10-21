namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemClassRepository : IRepository<ItemClass>
    {
        Task<ItemClass?> GetById(string itemClassId);
    }
}
