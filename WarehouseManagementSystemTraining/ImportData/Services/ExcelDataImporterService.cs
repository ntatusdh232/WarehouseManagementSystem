using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace ImportData.Services
{
    public class ExcelDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemRepository _itemRepository;
        private readonly ItemLotLocationRepository _itemLotLocation;
        public ExcelDataImporterService(ApplicationDbContext context)
        {
            _context = context;
            _itemRepository = new ItemRepository(_context);
            _itemLotLocation = new ItemLotLocationRepository(_context);   
        }

        public void ImportData(string filePath, string itemLotLocationFilePath)
        {
            var itemExcelData = ReadExcelFile(filePath);
            InsertDataIntoSqlServer(itemExcelData);

            var itemLotLocationExcelData = ReadExcelFile(itemLotLocationFilePath);

            Console.WriteLine("ItemLotLocation Data: " + itemLotLocationExcelData.Rows);

            InsertItemLotLocationDataIntoSqlServer(itemLotLocationExcelData);

        }

        public DataTable ReadExcelFile(string filePath, int sheetIndex = 0)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is invalid or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at path {filePath} does not exist.");
            }

            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = true }
                    });

                    if (sheetIndex < 0 || sheetIndex >= dataSet.Tables.Count)
                    {
                        throw new IndexOutOfRangeException($"Sheet index {sheetIndex} is out of range. The file has {dataSet.Tables.Count} sheets.");
                    }

                    var dataTable = dataSet.Tables[sheetIndex];

                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        throw new Exception("The Excel file is empty or no data could be read.");
                    }

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while reading the file: {ex.Message}");
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
            existingItem.ItemName = row["ItemName"]?.ToString() ?? "Null";
            existingItem.Unit = row["Unit"]?.ToString() ?? "Null";
            existingItem.MinimumStockLevel = DataParser.GetIntValue(row["MinimumStockLevel"]);
            existingItem.Price = DataParser.GetDecimalValue(row["Price"]);
            existingItem.PacketSize = DataParser.GetFloatValue(row["PacketSize"]);
            existingItem.PacketUnit = DataParser.GetPacketUnitValue(row["PacketUnit"]);
            existingItem.ItemType = row["ItemType"]?.ToString() ?? "Null";
            existingItem.ItemClassId = row["ItemType"]?.ToString() ?? "Null";

            _itemRepository.UpdateItem(existingItem);
        }

        private Item CreateNewItem(DataRow row)
        {
            return new Item
            (
                itemType: row["ItemType"]?.ToString() ?? "Null",
                itemId: row["ItemId"]?.ToString() ?? "Null",
                itemName: row["ItemName"]?.ToString() ?? "Null",
                unit: row["Unit"]?.ToString() ?? "Null",
                minimumStockLevel: DataParser.GetIntValue(row["MinimumStockLevel"]),
                price: DataParser.GetDecimalValue(row["Price"]),
                packetSize: DataParser.GetFloatValue(row["PacketSize"]),
                packetUnit: DataParser.GetPacketUnitValue(row["PacketUnit"]),
                itemClassId: row["ItemType"]?.ToString() ?? "Null"
            );
        }

        private void InsertItemLotLocationDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Dont Have Date In Execl.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ProcessItemLotLocationDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Import ItemLotLocation Data Success.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error ItemLotLocation when Import: {ex.Message}");
            }
        }

        private void ProcessItemLotLocationDataRows(DataTable dataTable)
        {
            int batchSize = 100;
            int processedRecords = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (TryProcessItemLotLocaionRow(row))
                {
                    processedRecords++;
                    if (processedRecords % batchSize == 0) _itemLotLocation.SaveChanges();
                }
            }

            if (processedRecords % batchSize != 0) _itemLotLocation.SaveChanges();
        }

        private bool TryProcessItemLotLocaionRow(DataRow row)
        {
            if (!ValidateForeignKeys(row)) return false;

            string lotId = row["LotId"]?.ToString()?.Trim() ?? throw new Exception("LotId Not Found");
            string locationId = row["LocationId"]?.ToString()?.Trim() ?? throw new Exception("LocationId Not Found");

            // Kiểm tra nếu LotId và LocationId đã tồn tại
            var existingItemLotLocation = _itemLotLocation.GetItemLotLocationByLotAndLocation(lotId, locationId);
            if (existingItemLotLocation != null)
            {
                Console.WriteLine($"ItemLotLocation already exists for LotId: {lotId}, LocationId: {locationId}");
                return false; // Không thêm mới
            }

            var itemLotLocation = CreateNewItemLotLocation(row);
            _itemLotLocation.AddItem(itemLotLocation);

            return true;
        }



        private bool ValidateForeignKeys(DataRow row)
        {
            string lotId = row["LotId"]?.ToString()?.Trim();
            string locationId = row["LocationId"]?.ToString()?.Trim();

            if (!_context.itemsLot.Any(l => l.LotId == lotId))
            {
                Console.WriteLine($"LotId {lotId} not found.");
                return false;
            }

            if (!_context.locations.Any(l => l.LocationId == locationId))
            {
                Console.WriteLine($"LocationId {locationId} not found.");
                return false;
            }

            return true;
        }


        private ItemLotLocation CreateNewItemLotLocation(DataRow row)
        {
            string lotId = row["LotId"]?.ToString()?.Trim() ?? throw new Exception("LotId is required");
            string locationId = row["LocationId"]?.ToString()?.Trim() ?? throw new Exception("LocationId is required");

            float quantityPerLocation;
            if (!float.TryParse(row["QuantityPerLocation"]?.ToString(), out quantityPerLocation))
            {
                Console.WriteLine($"Invalid QuantityPerLocation for LotId {lotId}, defaulting to 0.");
                quantityPerLocation = 0; 
            }

            return new ItemLotLocation
            (
                itemLotId: lotId,
                locationId: locationId,
                quantityPerLocation: quantityPerLocation
            );
        }




    }
}
