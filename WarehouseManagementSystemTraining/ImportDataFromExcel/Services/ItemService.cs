namespace ImportDataFromExcel.Services
{
    public class ItemService
    {
        public void ImportItemsFromExcel(string excelFilePath, string connectionString)
        {
            DataTable excelData = ExcelFileReader.ReadExcelFile(excelFilePath);
            SqlDataInserter.InsertDataIntoSqlServer(excelData, connectionString);
        }
    }
}
