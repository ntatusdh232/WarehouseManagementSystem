using DocumentFormat.OpenXml.InkML;
using WMS.Domain.AggregateModels.ItemAggregate;

namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Warehouse : IAggregateRoot
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<Location> Locations { get; set; }
        public string LocationId { get; set; }


#pragma warning disable CS8618
        private Warehouse() { }

        public Warehouse(string warehouseId, string warehouseName, List<Location> locations, string locationId)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Locations = locations;
            LocationId = locationId;
        }

        public Warehouse(string warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }



#pragma warning restore CS8618

    }
}
