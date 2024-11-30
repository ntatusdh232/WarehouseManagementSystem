using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace ImportData.Services.ModelDataImporterServices
{
    public class ItemLotLocationDataImporterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ItemLotLocationRepository _itemLotLocation;

        public ItemLotLocationDataImporterService(ApplicationDbContext context, ItemLotLocationRepository itemLotLocation)
        {
            _context = context;
            _itemLotLocation = itemLotLocation;
        }

        public void InsertItemLotLocationDataIntoSqlServer(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("Dont Have Date In Execl.");
                return;
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ProcessItemLotLocationDataRows(dataTable);
                transaction.Commit();
                Console.WriteLine("Import ItemLotLocation Data Success.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error ItemLotLocation when Import: {ex.Message}");
            }
        }

        private void ProcessItemLotLocationDataRows(DataTable dataTable)
        {
            int batchSize = 100;
            int processedRecords = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                if (TryProcessItemLotLocaionRow(row))
                {
                    processedRecords++;
                    if (processedRecords % batchSize == 0) _itemLotLocation.SaveChanges();
                }
            }

            if (processedRecords % batchSize != 0) _itemLotLocation.SaveChanges();
        }

        private bool TryProcessItemLotLocaionRow(DataRow row)
        {
            if (!ValidateForeignKeys(row)) return false;

            string lotId = row["LotId"]?.ToString()?.Trim() ?? throw new Exception("LotId Not Found");
            string locationId = row["LocationId"]?.ToString()?.Trim() ?? throw new Exception("LocationId Not Found");

            var existingItemLotLocation = _itemLotLocation.GetItemLotLocationByLotAndLocation(lotId, locationId);
            if (existingItemLotLocation != null)
            {
                //Console.WriteLine($"     ItemLotLocation already exists for LotId: {lotId}, LocationId: {locationId}");
                return false;
            }

            var itemLotLocation = CreateNewItemLotLocation(row);
            _itemLotLocation.AddItem(itemLotLocation);

            return true;
        }



        private bool ValidateForeignKeys(DataRow row)
        {
            string lotId = row["LotId"]?.ToString()?.Trim();
            string locationId = row["LocationId"]?.ToString()?.Trim();

            if (!_context.itemsLot.Any(l => l.LotId == lotId))
            {
                //Console.WriteLine($"LotId {lotId} not found.");
                return false;
            }

            if (!_context.locations.Any(l => l.LocationId == locationId))
            {
                //Console.WriteLine($"LocationId {locationId} not found.");
                return false;
            }

            return true;
        }


        private ItemLotLocation CreateNewItemLotLocation(DataRow row)
        {
            string lotId = row["LotId"]?.ToString()?.Trim() ?? throw new Exception("LotId is required");
            string locationId = row["LocationId"]?.ToString()?.Trim() ?? throw new Exception("LocationId is required");

            float quantityPerLocation;
            if (!float.TryParse(row["QuantityPerLocation"]?.ToString(), out quantityPerLocation))
            {
                //Console.WriteLine($"Invalid QuantityPerLocation for LotId {lotId}, defaulting to 0.");
                quantityPerLocation = 0;
            }

            return new ItemLotLocation
            (
                itemLotId: lotId,
                locationId: locationId,
                quantityPerLocation: quantityPerLocation
            );
        }

    }
}
