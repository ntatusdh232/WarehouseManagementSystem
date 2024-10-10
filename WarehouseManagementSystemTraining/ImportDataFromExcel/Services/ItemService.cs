using ImportDataFromExcel.DataProcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportDataFromExcel.DataProcess;


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
