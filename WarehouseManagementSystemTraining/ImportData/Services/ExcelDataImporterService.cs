using DocumentFormat.OpenXml.InkML;
using WMS.Domain.AggregateModels.InventoryLogEntryAggregate;
using WMS.Domain.AggregateModels.ItemAggregate;
using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace ImportData.Services
{
    public class ExcelDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemRepository _itemRepository;
        private readonly ItemLotLocationRepository _itemLotLocation;
        private readonly InventoryLogEntryRepository _inventoryLogEntryRepository;

        public ExcelDataImporterService(ApplicationDbContext context)
        {
            _context = context;
            _itemRepository = new ItemRepository(_context);
            _itemLotLocation = new ItemLotLocationRepository(_context);
            _inventoryLogEntryRepository = new InventoryLogEntryRepository(_context);
        }

        public void ImportData(string filePath, string itemLotLocationFilePath, string InventoryLogEntryExcelFilePath)
        {
            var itemExcelData = ReadExcelFile(filePath);
            InsertDataIntoSqlServer(itemExcelData);

            var itemLotLocationExcelData = ReadExcelFile(itemLotLocationFilePath);
            InsertItemLotLocationDataIntoSqlServer(itemLotLocationExcelData);

            var inventoryLogEntryExcelData = ReadExcelFile(InventoryLogEntryExcelFilePath);
            InsertInventoryLogEntryDataIntoSqlServer(inventoryLogEntryExcelData);

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
                throw new FileNotFoundException($"    The file at path {filePath} does not exist.");
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

        #region
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
        #endregion

        #region
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

            var existingItemLotLocation = _itemLotLocation.GetItemLotLocationByLotAndLocation(lotId, locationId);
            if (existingItemLotLocation != null)
            {
                //Console.WriteLine($"     ItemLotLocation already exists for LotId: {lotId}, LocationId: {locationId}");
                return false;
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

        #endregion

        #region

        private void InsertInventoryLogEntryDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Dont Have Date In Execl.");
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
                    Console.WriteLine("Data validation failed. Skipping row.");
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
            if (!ValidateForeignKeys2(row)) return false;

            string itemId = row["ItemId"]?.ToString()?.Trim() ?? throw new Exception("LotId Not Found");
            string itemLotId = row["ItemLotId"]?.ToString()?.Trim() ?? throw new Exception("LocationId Not Found");

            var existingItemLotLocation = _inventoryLogEntryRepository.GetInventoryLogEntryByLotAndItem(itemId, itemLotId);
            if (existingItemLotLocation != null)
            {
                Console.WriteLine($"ItemLotLocation already exists for LotId: {itemId}, LocationId: {itemLotId}");
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
                Console.WriteLine($"Validation Error: ItemId {itemId} not found in database.");
                return false;
            }

            if (string.IsNullOrEmpty(itemLotId) || !_context.itemsLot.Any(l => l.LotId == itemLotId))
            {
                Console.WriteLine($"Validation Error: ItemLotId {itemLotId} not found in database.");
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
                itemLotId: row["ItemId"]?.ToString()?.Trim(),
                itemId: row["ItemLotId"]?.ToString()?.Trim() ,
                beforeQuantity: DataParser.GetFloatValue(row["BeforeQuantity"]),
                changedQuantity: DataParser.GetFloatValue(row["ChangedQuantity"]),
                receivedQuantity: DataParser.GetFloatValue(row["ReceivedQuantity"]),
                shippedQuantity: DataParser.GetFloatValue(row["ShippedQuantity"]),
                timestamp: DataParser.GetDateTimeValue(row["Timestamp"]),
                trackingTime: DataParser.GetDateTimeValue(row["TrackingTime"])
            );
        }


        #endregion

    }
}
