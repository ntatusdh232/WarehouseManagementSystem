namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemRepository : IRepository<ItemList>
    {
        Task<Item> Add(Item item);
        //Task<Item?> GetItemByEntityId(string entityId);
        Task<IEnumerable<Item>> GetItemById(string itemId);
        Task<IEnumerable<Item>> GetItemsByItemClass(string itemClassId);
        Task<ItemList> Update(ItemList item);


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
