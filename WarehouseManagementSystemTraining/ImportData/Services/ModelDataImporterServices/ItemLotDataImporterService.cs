using DocumentFormat.OpenXml.InkML;
using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace ImportData.Services.ModelDataImporterServices
{
    public class ItemLotDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemLotRepository _itemLot;

        public ItemLotDataImporterService(ApplicationDbContext context, ItemLotRepository itemLot)
        {
            _context = context;
            _itemLot = itemLot;
        }

        public void InsertItemLotDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Dont Have Date In Execl.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ProcessItemLotDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Import ItemLot Data Success.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ItemLot when Import: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                transaction.Rollback();
            }
        }

        private void ProcessItemLotDataRows(DataTable dataTable)
        {
            int batchSize = 100;
            int processedRecords = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (TryProcessItemLotRow(row))
                {
                    processedRecords++;
                    if (processedRecords % batchSize == 0) _itemLot.SaveChanges();
                }
            }

            if (processedRecords % batchSize != 0) _itemLot.SaveChanges();
        }

        private bool TryProcessItemLotRow(DataRow row)
        {
            if (!ValidateForeignKeys(row)) return false;

            string itemId = row["ItemId"]?.ToString()?.Trim() ?? throw new Exception("ItemId Not Found");
            string lotId = row["LotId"]?.ToString()?.Trim() ?? throw new Exception("LotId Not Found");

            var existingItem = _itemLot.GetItemLotByItem(itemId);
            if (existingItem != null)
            {
                //Console.WriteLine($"     ItemLotLocation already exists for LotId: {lotId}, LocationId: {locationId}");
                return false;
            }

            var existingItemLot = _itemLot.GetItemLotById(lotId);
            if (existingItemLot != null)
            {
                //Console.WriteLine($"ItemLotLocation already exists for ItemId: {itemId}, ItemLotId: {itemLotId}");
                return false;
            }

            var itemLot = CreateNewItemLot(row);
            _itemLot.AddItemLot(itemLot);

            return true;
        }



        private bool ValidateForeignKeys(DataRow row)
        {
            string itemId = row["ItemId"]?.ToString()?.Trim();

            if (!_context.items.Any(l => l.ItemId == itemId))
            {
                //Console.WriteLine($"LotId {lotId} not found.");
                return false;
            }

            return true;
        }


        private ItemLot CreateNewItemLot(DataRow row)
        {
            string itemId = row["ItemId"]?.ToString()?.Trim() ?? throw new Exception("ItemIdId is required");

            return new ItemLot
            (
                lotId: DataParser.GetStringValue(row["LotId"]),
                quantity: DataParser.GetFloatValue(row["Quantity"]),
                timestamp: DataParser.GetDateTimeValue(row["Timestamp"]),
                productionDate: DataParser.GetDateTimeValue(row["ProductionDate"]),
                expirationDate: DataParser.GetDateTimeValue(row["ExpirationDate"]),
                isIsolated: DataParser.GetBoolValue(row["IsIsolated"]),
                itemId: itemId
            );

        }
    }
}
