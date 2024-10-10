namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location
    {
        public string LocationId { get; set; }  
        public List<ItemLot> ItemLots { get; set; }
    }
}
