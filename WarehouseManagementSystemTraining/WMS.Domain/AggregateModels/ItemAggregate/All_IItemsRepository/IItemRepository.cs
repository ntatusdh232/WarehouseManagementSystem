namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        //Task<Item?> GetItemByEntityId(string entityId);
        Task<Item> GetItemById(string itemId);
        Task<IEnumerable<Item>> GetItemsByItemClass(string itemClassId);
        Task<ItemList> Update(ItemList item);
        Task Add(Item item, CancellationToken cancellationToken);
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item?> GetItemByEntityId(string entityId);
        Task Update(Item item, string itemClassId, CancellationToken cancellationToken);


        Task<IEnumerable<ItemList>> GetItemLists();
        Task<ItemList> GetItemId(string itemId);
        IEnumerable<ItemList> GetItems();
        IEnumerable<ItemList> GetSort(string sortField, string sortDirection, IEnumerable<ItemList> items);
        IXLWorksheet? GetItemListWorkSheet(IEnumerable<ItemList> items, IXLWorksheet? worksheet);
        Task<Item> AddItem(Item item);
        List<ItemList> GetPageItems(IEnumerable<ItemList> items, int pageNumber, int pageSize);
        Task UpdateItem(ItemList item);


    }
}
