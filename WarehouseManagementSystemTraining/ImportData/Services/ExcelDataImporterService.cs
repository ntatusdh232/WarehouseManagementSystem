namespace ImportData.Services
{
    public class ExcelDataImporterService
    {
        private readonly ExcelReaderService _excelReaderService;
        private readonly ItemDataImporterService _itemDataImporterService;
        private readonly ItemLotLocationDataImporterService _itemLotLocationDataImporterService;
        private readonly InventoryLogEntryDataImporterService _inventoryLogEntryDataImporterService;
        private readonly ApplicationDbContext _context;

        public ExcelDataImporterService(ApplicationDbContext context)
        {
            _excelReaderService = new ExcelReaderService();
            _itemDataImporterService = new ItemDataImporterService(context, new ItemRepository(context));
            _itemLotLocationDataImporterService = new ItemLotLocationDataImporterService(context, new ItemLotLocationRepository(context));
            _inventoryLogEntryDataImporterService = new InventoryLogEntryDataImporterService(context, new InventoryLogEntryRepository(context));
            _context = context;
        }

        public void ImportData(string filePath, string itemLotLocationFilePath, string InventoryLogEntryExcelFilePath)
        {
            if (_excelReaderService == null || _itemDataImporterService == null ||
                _itemLotLocationDataImporterService == null || _inventoryLogEntryDataImporterService == null)
            {
                throw new InvalidOperationException("One or more services are not initialized.");
            }

            var itemExcelData = _excelReaderService.ReadExcelFile(filePath);
            var itemLotLocationExcelData = _excelReaderService.ReadExcelFile(itemLotLocationFilePath);
            var inventoryLogEntryExcelData = _excelReaderService.ReadExcelFile(InventoryLogEntryExcelFilePath);

            _itemDataImporterService.InsertDataIntoSqlServer(itemExcelData);
            _itemLotLocationDataImporterService.InsertItemLotLocationDataIntoSqlServer(itemLotLocationExcelData);
            _inventoryLogEntryDataImporterService.InsertInventoryLogEntryDataIntoSqlServer(inventoryLogEntryExcelData);
        }
    }
}
