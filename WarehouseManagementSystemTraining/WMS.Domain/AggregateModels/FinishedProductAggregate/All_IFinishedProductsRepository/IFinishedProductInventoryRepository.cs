namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductInventoryRepository : IRepository<FinishedProductInventory>
    {
        Task<IEnumerable<FinishedProductInventory>> GetProductInventoriesByItemId(string itemId ,CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetPos();
        Task<FinishedProductInventory> GetInventory(string itemId, string unit, string purchaseOrderNumber);
        Task Update(FinishedProductReceiptEntry Entry);


        Task<FinishedProductInventory> Add(FinishedProductInventory finishedProductInventory);
        Task<IEnumerable<FinishedProductInventory>> GetAllFinishedProductInventory();
        Task Remove(string finishedProductInventoryId);
        Task<FinishedProductInventory> Update(FinishedProductInventory finishedProductInventory);
    }
}
