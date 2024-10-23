namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location : IAggregateRoot
    {
        public string LocationId { get; set; }  
        public List<ItemLot> ItemLots { get; set; }

        public void LocationUpdate(string locationId, List<ItemLot> itemLots)
        {
            LocationId = locationId;
            ItemLots = itemLots;
        }
    }

}
