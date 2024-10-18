namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location : IAggregateRoot
    {
        public string LocationId { get; set; }  
        public List<ItemLot> ItemLots { get; set; }
        public string WarehouseId { get; set; }
    }

    public class LocatonList 
    {
        public string LocationId { get; set; }
        public string WarehouseId { get; set; }
    }
}
