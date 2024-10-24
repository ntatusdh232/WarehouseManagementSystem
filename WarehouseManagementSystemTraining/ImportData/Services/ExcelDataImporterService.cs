﻿namespace ImportData.Services
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
                Console.WriteLine("Không có dữ liệu trong file Excel.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ProcessDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Dữ liệu đã được nhập thành công.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Lỗi khi nhập dữ liệu: {ex.Message}");
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
            string itemId = row["ItemId"]?.ToString()?.Trim();
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
            existingItem.ItemName = row["ItemName"]?.ToString();
            existingItem.Unit = row["Unit"]?.ToString();
            existingItem.MinimumStockLevel = DataParser.GetIntValue(row["MinimumStockLevel"]);
            existingItem.Price = DataParser.GetDecimalValue(row["Price"]);
            existingItem.PacketSize = DataParser.GetFloatValue(row["PacketSize"]);
            existingItem.PacketUnit = DataParser.GetPacketUnitValue(row["PacketUnit"]);
            existingItem.ItemType = row["ItemType"]?.ToString();

            _itemRepository.UpdateItem(existingItem);
        }

        private Item CreateNewItem(DataRow row)
        {
            return new Item
            {
                ItemId = row["ItemId"]?.ToString(),
                ItemName = row["ItemName"]?.ToString(),
                Unit = row["Unit"]?.ToString(),
                MinimumStockLevel = DataParser.GetIntValue(row["MinimumStockLevel"]),
                Price = DataParser.GetDecimalValue(row["Price"]),
                PacketSize = DataParser.GetFloatValue(row["PacketSize"]),
                PacketUnit = DataParser.GetPacketUnitValue(row["PacketUnit"]),
                ItemType = row["ItemType"]?.ToString()
            };
        }
    }
}
