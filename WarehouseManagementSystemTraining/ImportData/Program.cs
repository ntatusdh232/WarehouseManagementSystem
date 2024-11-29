namespace ImportData
{
    class Program
    {
        static void Main(string[] args)
        {
            string ItemExcelFilePath = @"D:\CODE\VisualStudio\C#\TRAINING\Week11\Data\ITEMS.xlsx";
            string connectionString = "Data Source=PhatHuyBK\\SQLEXPRESS;Initial Catalog=WarehouseManagementSystem;Integrated Security=True;Encrypt=False";
            string ItemLotLocationExcelFilePath = @"D:\CODE\VisualStudio\C#\TRAINING\Week15\SQLCODE\ItemLotLocation.xlsx";
            string InventoryLogEntryExcelFilePath = @"D:\CODE\VisualStudio\C#\TRAINING\Week15\SQLCODE\InventoryLogEntry.xlsx";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            try
            {
                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var importer = new ExcelDataImporterService(context);
                    importer.ImportData(ItemExcelFilePath, ItemLotLocationExcelFilePath, InventoryLogEntryExcelFilePath);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}
