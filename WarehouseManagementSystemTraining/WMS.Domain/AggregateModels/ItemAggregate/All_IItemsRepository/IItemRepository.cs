namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        //Task<Item?> GetItemByEntityId(string entityId);
        Task<Item> GetItemById(string itemId);
        Task<Item> GetItemByIdAndUnit(string itemId, string Unit);
        Task<IEnumerable<Item>> GetItemsByItemClass(string itemClassId);
        Task<Item> Update(Item item);
        Task Add(Item item);
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item?> GetItemByEntityId(string entityId);
        Task Update(Item item, string itemClassId, CancellationToken cancellationToken);


        Task<IEnumerable<Item>> GetItemLists();
        Task<Item> GetItemId(string itemId);
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetSort(string sortField, string sortDirection, IEnumerable<Item> items);
        IXLWorksheet? GetItemListWorkSheet(IEnumerable<Item> items, IXLWorksheet? worksheet);
        Task<Item> AddItem(Item item);
        List<Item> GetPageItems(IEnumerable<Item> items, int pageNumber, int pageSize);
        Task UpdateItem(Item item);


    }
}
