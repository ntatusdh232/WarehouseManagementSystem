namespace ImportData.Services.ModelDataImporterServices
{
    public class InventoryLogEntryDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly InventoryLogEntryRepository _inventoryLogEntryRepository;

        public InventoryLogEntryDataImporterService(ApplicationDbContext context, InventoryLogEntryRepository inventoryLogEntryRepository)
        {
            _context = context;
            _inventoryLogEntryRepository = inventoryLogEntryRepository;
        }

        public void InsertInventoryLogEntryDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("No data found in Excel.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ProcessInventoryLogEntryDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Import InventoryLogEntry Data Success.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error InventoryLogEntry when Import: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                transaction.Rollback();
            }
        }

        private void ProcessInventoryLogEntryDataRows(DataTable dataTable)
        {
            int batchSize = 100;
            int processedRecords = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (!ValidateForeignKeys2(row))
                {
                    string itemId = row["ItemId"]?.ToString()?.Trim() ?? "NULL";
                    //Console.WriteLine($"Skipping row due to missing foreign key: ItemId = {itemId}");
                    continue;
                }

                if (TryProcessInventoryLogEntryRow(row))
                {
                    processedRecords++;

                    if (processedRecords % batchSize == 0)
                    {
                        _inventoryLogEntryRepository.SaveChanges();
                    }
                }
            }

            if (processedRecords % batchSize != 0)
            {
                _inventoryLogEntryRepository.SaveChanges();
            }
        }

        private bool TryProcessInventoryLogEntryRow(DataRow row)
        {
            string itemId = row["ItemId"]?.ToString()?.Trim();
            string itemLotId = row["ItemLotId"]?.ToString()?.Trim();

            var existingItemLotLocation = _inventoryLogEntryRepository.GetInventoryLogEntryByLotAndItem(itemId, itemLotId);
            if (existingItemLotLocation != null)
            {
                //Console.WriteLine($"ItemLotLocation already exists for ItemId: {itemId}, ItemLotId: {itemLotId}");
                return false;
            }

            var inventoryLogEntry = CreateNewInventoryLogEntry(row);
            _inventoryLogEntryRepository.AddItem(inventoryLogEntry);

            return true;
        }

        private bool ValidateForeignKeys2(DataRow row)
        {
            string itemId = row["ItemId"]?.ToString()?.Trim();
            string itemLotId = row["ItemLotId"]?.ToString()?.Trim();

            if (string.IsNullOrEmpty(itemId) || !_context.items.Any(i => i.ItemId == itemId))
            {
                //Console.WriteLine($"Validation Error: ItemId {itemId ?? "NULL"} not found in database.");
                return false;
            }

            if (string.IsNullOrEmpty(itemLotId) || !_context.itemsLot.Any(l => l.LotId == itemLotId))
            {
                //Console.WriteLine($"Validation Error: ItemLotId {itemLotId ?? "NULL"} not found in database.");
                return false;
            }

            return true;
        }

        private InventoryLogEntry CreateNewInventoryLogEntry(DataRow row)
        {
            if (row["BeforeQuantity"] == null || row["ChangedQuantity"] == null)
                throw new Exception("Missing required quantity fields.");

            return new InventoryLogEntry
            (
                itemId: DataParser.GetStringValue(row["ItemId"]),
                itemLotId: DataParser.GetStringValue(row["ItemLotId"]),
                beforeQuantity: DataParser.GetFloatValue(row["BeforeQuantity"]),
                changedQuantity: DataParser.GetFloatValue(row["ChangedQuantity"]),
                receivedQuantity: DataParser.GetFloatValue(row["ReceivedQuantity"]),
                shippedQuantity: DataParser.GetFloatValue(row["ShippedQuantity"]),
                timestamp: DataParser.GetDateTimeValue(row["Timestamp"]),
                trackingTime: DataParser.GetDateTimeValue(row["TrackingTime"])
            );
        }



    }
}
