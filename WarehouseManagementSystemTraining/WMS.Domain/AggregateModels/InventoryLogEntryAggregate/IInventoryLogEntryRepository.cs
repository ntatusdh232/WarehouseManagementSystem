namespace WMS.Domain.AggregateModels.InventoryLogEntryAggregate
{
    public interface IInventoryLogEntryRepository : IRepository<InventoryLogEntry>
    {
        Task<InventoryLogEntry> Add(InventoryLogEntry inventoryLogEntry);
        Task<InventoryLogEntry> Update(InventoryLogEntry inventoryLogEntry);
        Task<IEnumerable<InventoryLogEntry>> UpdateEntries(IEnumerable<InventoryLogEntry> updatedLogEntries);
        Task Remove(string itemLotId);
        Task<InventoryLogEntry> GetLatestLogEntry();
        Task<IEnumerable<InventoryLogEntry>> GetLatestLogEntries();
        Task<InventoryLogEntry> GetPreviousLogEntry();
        Task<InventoryLogEntry> GetLogEntryId(string logEntryId);
    }
}
