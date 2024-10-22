namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location : IAggregateRoot
    {
        public string LocationId { get; set; }  
        public List<ItemLot> ItemLots { get; set; }
        public string WarehouseId { get; set; }

        public void LocationUpdate(string locationId, string warehouseId)
        {
            LocationId = locationId;
            WarehouseId = warehouseId;
        }
    }

    public class LocatonList 
    {
        public string LocationId { get; set; }
        public string WarehouseId { get; set; }
    }

}
