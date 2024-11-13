namespace WMS.Domain.AggregateModels.LocationAggregate
{
    public class Location : Entity, IAggregateRoot
    {
        public string LocationId { get; set; }  
        public List<ItemLot> ItemLots { get; set; }

#pragma warning disable CS8618
        private Location() { }

        public Location(string locationId)
        {
            LocationId = locationId;
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
