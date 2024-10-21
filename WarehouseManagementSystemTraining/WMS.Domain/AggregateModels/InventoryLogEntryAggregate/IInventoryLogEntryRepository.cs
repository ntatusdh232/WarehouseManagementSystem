namespace WMS.Domain.AggregateModels.InventoryLogEntryAggregate
{
    public interface IInventoryLogEntryRepository : IRepository<InventoryLogEntry>
    {
        Task<InventoryLogEntry> Add(InventoryLogEntry inventoryLogEntry);
        Task<InventoryLogEntry> Update(string ItemLotId, InventoryLogEntry inventoryLogEntry);
        Task<InventoryLogEntry> UpdateEntries(string ItemLotId, InventoryLogEntry inventoryLogEntry);
        Task Remove(string ItemLotId);
        Task<IEnumerable<InventoryLogEntry>> GetLatestLogEntry();
        Task<IEnumerable<InventoryLogEntry>> GetLatestLogEntries();
        Task<IEnumerable<InventoryLogEntry>> GetPreviousLogEntry();
        Task<IEnumerable<InventoryLogEntry>> GetLogEntryId();
    }
}
