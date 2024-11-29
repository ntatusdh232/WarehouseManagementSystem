namespace WMS.Domain.AggregateModels.ItemLotLocationAggregate
{
    public class ItemLotLocation : Entity, IAggregateRoot
    {
        [Key]
        public string ItemLotLocationId { get; set; }
        public double QuantityPerLocation { get; private set; }

        [ForeignKey("ItemLot")]
        public string LotId { get; private set; }
        public ItemLot ItemLot { get; private set; }

        [ForeignKey("Location")]
        public string LocationId { get; private set; }
        public Location Location { get; private set; }

#pragma warning disable CS8618
        private ItemLotLocation() { }

        public ItemLotLocation(string itemLotId, string locationId, double quantityPerLocation)
        {
            ItemLotLocationId = Guid.NewGuid().ToString();
            LotId = itemLotId;
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }

        public ItemLotLocation(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }

        public void UpdateQuantity(double quantity)
        {
            QuantityPerLocation += quantity;
        }
#pragma warning restore CS8618
    }
}
