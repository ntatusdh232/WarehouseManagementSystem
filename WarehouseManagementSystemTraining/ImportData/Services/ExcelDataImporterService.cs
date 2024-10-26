using ImportData.Repositories;
using ImportData.Utilities;
using System.Data;
using System.IO;
using ExcelDataReader;

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
            DataTable excelData = ReadExcelFile(filePath);
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
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
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

            int batchSize = 100;
            int processedRecords = 0;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string itemId = row["ItemId"]?.ToString().Trim();
                        if (string.IsNullOrWhiteSpace(itemId))
                        {
                            Console.WriteLine("Mặt hàng không có ItemId, bỏ qua hàng này.");
                            continue;
                        }

                        var item = _itemRepository.GetItemById(itemId);
                        if (item != null)
                        {
                            UpdateItem(item, row);
                            Console.WriteLine($"Cập nhật mặt hàng: {itemId}");
                        }
                        else
                        {
                            item = CreateNewItem(row);
                            _itemRepository.AddItem(item);
                            Console.WriteLine($"Thêm mới mặt hàng: {itemId}");
                        }

                        processedRecords++;

                        if (processedRecords % batchSize == 0)
                        {
                            _itemRepository.SaveChanges();
                        }
                    }

                    if (processedRecords % batchSize != 0)
                    {
                        _itemRepository.SaveChanges();
                    }

                    // Commit the transaction
                    transaction.Commit();
                    Console.WriteLine($"Đã nhập {processedRecords} mặt hàng vào cơ sở dữ liệu.");
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    transaction.Rollback();
                    Console.WriteLine($"Lỗi khi nhập dữ liệu: {ex.Message}");
                }
            }
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
