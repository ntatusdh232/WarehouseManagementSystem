using WMS.Domain.AggregateModels.ItemLotLocationAggregate;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location : Entity, IAggregateRoot
    {
        [Key]
        public string LocationId { get; set; }

        [ForeignKey("Warehouse")]
        public string WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public List<ItemLot> ItemLots { get; set; }
        public List<ItemLotLocation> ItemLotLocations { get; set; }

#pragma warning disable CS8618
        private Location() { }

        public Location(string locationId, string warehouseId)
        {
            LocationId = locationId;
            WarehouseId = warehouseId;
        }
        public Location(string locationId, List<ItemLot> itemLots)
        {
            LocationId = locationId;
            ItemLots = itemLots;
        }

#pragma warning restore CS8618

        public void LocationUpdate(string locationId, List<ItemLot> itemLots)
        {
            LocationId = locationId;
            ItemLots = itemLots;
        }
    }

}
