namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductInventoryRepository : IRepository<FinishedProductInventory>
    {
        Task<FinishedProductInventory> Add(FinishedProductInventory finishedProductInventory);
        Task<IEnumerable<FinishedProductInventory>> GetAllFinishedProductInventory();
        Task Remove(string finishedProductInventoryId);
        Task<FinishedProductInventory> Update(string finishedProductInventoryId, FinishedProductInventory finishedProductInventory);
    }
}
