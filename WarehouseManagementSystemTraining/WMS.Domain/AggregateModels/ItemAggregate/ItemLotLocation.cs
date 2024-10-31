namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemLotLocation : IAggregateRoot
    {
        public string ItemLotId { get; set; }

        public List<Location> Locations { get; set; }
        public bool IsIsolated { get; set; }
        public string ItemId { get; set; }

        public ItemLotLocation(string itemLotId, List<Location> locations, bool isIsolated, string itemId)
        {
            ItemLotId = itemLotId;
            Locations = locations;
            IsIsolated = isIsolated;
            ItemId = itemId;
        }
    }
}
