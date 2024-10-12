namespace WMS.Domain.AggregateModels.InventoryLogEntryAggregate
{
    public class InventoryLogEntry
    {
        public string ItemLotId { get; set; }
        public double BeforeQuantity { get; set; } 
        public double ChangedQuantity { get; set; }
        public double ReceivedQuantity { get; set; }
        public double ShippedQuantity { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime TrackingTime { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; } 

    }
}
