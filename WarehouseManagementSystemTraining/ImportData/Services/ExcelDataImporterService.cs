namespace ImportData.Services
{
    public class ExcelDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemRepository _itemRepository;

        public ExcelDataImporterService(ApplicationDbContext context)
        {
            _context = context;
            _itemRepository = new ItemRepository(_context);
        }

        public void ImportData(string filePath)
        {
            var excelData = ReadExcelFile(filePath);
            InsertDataIntoSqlServer(excelData);
        }

        private DataTable ReadExcelFile(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                return reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = true }
                }).Tables[0];
            }
        }

        private void InsertDataIntoSqlServer(DataTable dataTable)
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
                Console.WriteLine("Import Data Success.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error when Import: {ex.Message}");
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
            existingItem.ItemName = row["ItemName"]?.ToString() ?? "Null";
            existingItem.Unit = row["Unit"]?.ToString() ?? "Null";
            existingItem.MinimumStockLevel = DataParser.GetIntValue(row["MinimumStockLevel"]);
            existingItem.Price = DataParser.GetDecimalValue(row["Price"]);
            existingItem.PacketSize = DataParser.GetFloatValue(row["PacketSize"]);
            existingItem.PacketUnit = DataParser.GetPacketUnitValue(row["PacketUnit"]);
            existingItem.ItemType = row["ItemType"]?.ToString() ?? "Null";
            existingItem.ItemClassId = Guid.NewGuid().ToString();

            _itemRepository.UpdateItem(existingItem);
        }

        private Item CreateNewItem(DataRow row)
        {
            return new Item
            (
                row["ItemType"]?.ToString() ?? "Null",
                row["ItemId"]?.ToString() ?? "Null",
                row["ItemName"]?.ToString() ?? "Null",
                row["Unit"]?.ToString() ?? "Null",
                DataParser.GetIntValue(row["MinimumStockLevel"]),
                DataParser.GetDecimalValue(row["Price"]),
                DataParser.GetFloatValue(row["PacketSize"]),
                DataParser.GetPacketUnitValue(row["PacketUnit"]),
                Guid.NewGuid().ToString()
            );
        }
    }
}
