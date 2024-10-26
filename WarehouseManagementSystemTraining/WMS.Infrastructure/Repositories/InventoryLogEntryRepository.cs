namespace WMS.Infrastructure.Repositories
{
    internal class InventoryLogEntryRepository : BaseRepository, IInventoryLogEntryRepository
    {
        public InventoryLogEntryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<InventoryLogEntry> Add(InventoryLogEntry inventoryLogEntry)
        {
            var existingInventoryLogEntry = await _context.inventoryLogEntries.FindAsync(inventoryLogEntry.ItemLotId);
            if (existingInventoryLogEntry == inventoryLogEntry)
            {
                throw new ArgumentException($"InventoryLogEntry with ID {existingInventoryLogEntry.ItemLotId} already exists.");
            }
            await _context.inventoryLogEntries.AddAsync(inventoryLogEntry);
            await _context.SaveChangesAsync();
            return inventoryLogEntry;
        }

        public async Task<IEnumerable<InventoryLogEntry>> GetLatestLogEntries()
        {
            var latestLogEntries = await _context.inventoryLogEntries.OrderByDescending(x => x.Timestamp).Take(10).ToListAsync();
            return latestLogEntries;
        }

        public async Task<InventoryLogEntry> GetLatestLogEntry()
        {
            var latestLogEntry = await _context.inventoryLogEntries.OrderByDescending(x => x.Timestamp).FirstOrDefaultAsync();
            if (latestLogEntry == null)
            {
                throw new ArgumentException($"LatestLogEntry does not exists.");
            }
            return latestLogEntry;
        }

        public async Task<InventoryLogEntry> GetLogEntryId(string logEntryId)
        {
            var logEntry = await _context.inventoryLogEntries.Where(x => x.ItemLotId == logEntryId).FirstOrDefaultAsync();
            if(logEntry is null)
            {
                throw new ArgumentException($"LogEntry does not exists.");
            }
            return logEntry;
        }

        public async Task<InventoryLogEntry> GetPreviousLogEntry()
        {
            var previousLogEntry = await _context.inventoryLogEntries.OrderByDescending(x => x.Timestamp).Skip(1).FirstOrDefaultAsync();
            if (previousLogEntry is null)
            {
                throw new ArgumentException($"LogEntry does not exists.");
            }
            return previousLogEntry;
        }

        public async Task Remove(string itemLotId)
        {
            var existingLogEntry = await _context.inventoryLogEntries.FindAsync(itemLotId);
            if (existingLogEntry is null)
            {
                throw new ArgumentException($"LogEntry does not exists.");
            }
            _context.inventoryLogEntries.Remove(existingLogEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<InventoryLogEntry> Update(InventoryLogEntry inventoryLogEntry)
        {
            var existingLogEntry = await _context.inventoryLogEntries.FindAsync(inventoryLogEntry.ItemLotId);
            if (existingLogEntry is null)
            {
                throw new ArgumentException($"LogEntry does not exists.");
            }
            existingLogEntry.Update(inventoryLogEntry.BeforeQuantity, inventoryLogEntry.ChangedQuantity, inventoryLogEntry.ReceivedQuantity, inventoryLogEntry.ShippedQuantity, inventoryLogEntry.Timestamp, inventoryLogEntry.TrackingTime);
            await _context.SaveChangesAsync();
            return inventoryLogEntry;
        }

        public async Task<IEnumerable<InventoryLogEntry>> UpdateEntries(IEnumerable<InventoryLogEntry> updatedLogEntries)
        {
            // Lấy danh sách các ID của InventoryLogEntry cần cập nhật
            var itemLotIds = updatedLogEntries.Select(entry => entry.ItemLotId).ToList();

            // Tìm tất cả các bản ghi InventoryLogEntry có ItemLotId trong cơ sở dữ liệu
            var existingLogEntries = await _context.inventoryLogEntries
                                                    .Where(entry => itemLotIds.Contains(entry.ItemLotId))
                                                    .ToListAsync();

            // Tạo danh sách các bản ghi không tìm thấy
            var notFoundIds = itemLotIds.Except(existingLogEntries.Select(entry => entry.ItemLotId)).ToList();

            // Nếu có bất kỳ bản ghi nào không tìm thấy, ném ra ngoại lệ
            if (notFoundIds.Any())
            {
                throw new ArgumentException($"InventoryLogEntries with ItemLotId {string.Join(", ", notFoundIds)} not found.");
            }

            // Cập nhật các thuộc tính của các bản ghi
            foreach (var existingEntry in existingLogEntries)
            {
                var updatedEntry = updatedLogEntries.Single(entry => entry.ItemLotId == existingEntry.ItemLotId);
                existingEntry.Update(updatedEntry.BeforeQuantity, updatedEntry.ChangedQuantity, updatedEntry.ReceivedQuantity, updatedEntry.ShippedQuantity, updatedEntry.Timestamp, updatedEntry.TrackingTime);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            return existingLogEntries; // Trả về danh sách InventoryLogEntry đã được cập nhật
        }
    }
}
