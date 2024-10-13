namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemList>> GetItemLists();
        Task<ItemList> GetItemId(string itemId);
        IEnumerable<ItemList> GetItems();
    }
}
