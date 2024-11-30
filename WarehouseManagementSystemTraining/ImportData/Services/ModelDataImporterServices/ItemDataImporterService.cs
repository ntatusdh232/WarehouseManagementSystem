namespace ImportData.Services.ModelDataImporterServices
{
    public class ItemDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemRepository _itemRepository;

        public ItemDataImporterService(ApplicationDbContext context, ItemRepository itemRepository)
        {
            _context = context;
            _itemRepository = itemRepository;
        }

        public void InsertDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Dont Have Date In Execl.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                ProcessDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Import Item Data Success.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error Item when Import: {ex.Message}");
            }
        }

        private void ProcessDataRows(DataTable dataTable)
        {
            int batchSize = 100;
            int processedRecords = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (TryProcessRow(row))
                {
                    processedRecords++;
                    if (processedRecords % batchSize == 0) _itemRepository.SaveChanges();
                }
            }

            if (processedRecords % batchSize != 0) _itemRepository.SaveChanges();
        }

        private bool TryProcessRow(DataRow row)
        {
            string itemId = row["ItemId"]?.ToString()?.Trim() ?? throw new Exception("Not Found");

            if (string.IsNullOrWhiteSpace(itemId)) return false;

            var item = _itemRepository.GetItemById(itemId);
            if (item != null)
            {
                UpdateItem(item, row);
            }
            else
            {
                item = CreateNewItem(row);
                _itemRepository.AddItem(item);
            }

            return true;
        }

        private void UpdateItem(Item existingItem, DataRow row)
        {
            existingItem.ItemName = DataParser.GetStringValueOrNull(row["ItemName"]);
            existingItem.Unit = DataParser.GetStringValueOrNull(row["Unit"]);
            existingItem.MinimumStockLevel = DataParser.GetIntValue(row["MinimumStockLevel"]);
            existingItem.Price = DataParser.GetDecimalValue(row["Price"]);
            existingItem.PacketSize = DataParser.GetFloatValue(row["PacketSize"]);
            existingItem.PacketUnit = DataParser.GetPacketUnitValue(row["PacketUnit"]);
            existingItem.ItemType = DataParser.GetStringValueOrNull(row["ItemType"]);
            existingItem.ItemClassId = DataParser.GetStringValueOrNull(row["ItemType"]);

            _itemRepository.UpdateItem(existingItem);
        }

        private Item CreateNewItem(DataRow row)
        {
            return new Item
            (
                itemType: DataParser.GetStringValueOrNull(row["ItemType"]),
                itemId: DataParser.GetStringValueOrNull(row["ItemId"]),
                itemName: DataParser.GetStringValueOrNull(row["ItemName"]),
                unit: DataParser.GetStringValueOrNull(row["Unit"]),
                minimumStockLevel: DataParser.GetIntValue(row["MinimumStockLevel"]),
                price: DataParser.GetDecimalValue(row["Price"]),
                packetSize: DataParser.GetFloatValue(row["PacketSize"]),
                packetUnit: DataParser.GetPacketUnitValue(row["PacketUnit"]),
                itemClassId: DataParser.GetStringValueOrNull(row["ItemType"])
            );
        }
    }
}
