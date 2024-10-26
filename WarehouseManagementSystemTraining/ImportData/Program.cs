namespace ImportData
{


    class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath = @"D:\CODE\VisualStudio\C#\TRAINING\Week11\Data\ITEMS.xlsx";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=PhatHuyBK\\SQLEXPRESS;Initial Catalog=WarehouseManagementSystem;Integrated Security=True;Encrypt=False");

            try
            {
                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var importer = new ExcelDataImporterService(context);
                    importer.ImportData(excelFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}
