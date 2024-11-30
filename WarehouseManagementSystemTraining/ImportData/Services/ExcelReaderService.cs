namespace ImportData.Services
{
    public class ExcelReaderService
    {
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
    }
}
