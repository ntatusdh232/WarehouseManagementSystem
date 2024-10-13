namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemList>> GetItemLists();
        Task<ItemList> GetItemId(string itemId);
        IEnumerable<ItemList> GetItems();
        IEnumerable<ItemList> GetSort(string sortField, string sortDirection, IEnumerable<ItemList> items);
        IXLWorksheet? GetItemListworksheet(IEnumerable<ItemList> items, IXLWorksheet? worksheet);
        Task<Item> AddItem(Item item);
        List<ItemList> GetPageItems(IEnumerable<ItemList> items, int pageNumber, int pageSize);
        Task UpdateItem(ItemList item);


    }
}
