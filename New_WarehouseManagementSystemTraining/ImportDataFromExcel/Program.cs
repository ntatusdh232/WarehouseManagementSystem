namespace ImportDataFromExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath = @"D:\CODE\VisualStudio\C#\TRAINING\Week11\Data\ITEMS.xlsx";
            string connectionString = "Data Source=PhatHuyBK\\SQLEXPRESS;Initial Catalog=WarehouseManagementSystem2;Integrated Security=True;Encrypt=False";

            ItemService itemService = new ItemService();
            itemService.ImportItemsFromExcel(excelFilePath, connectionString);
        }
    }
}
