namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemClassRepository : IRepository<ItemClass>
    {
        Task<IEnumerable<ItemClass>> GetById(string ItemClassId);
    }
}
