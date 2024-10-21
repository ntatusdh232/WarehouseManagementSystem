namespace WMS.Domain.AggregateModels.InventoryLogEntryAggregate
{
    public class InventoryLogEntry : IAggregateRoot
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public InventoryLogEntry()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

        public void Update(double beforeQuantity, double changedQuantity, double receivedQuantity, double shippedQuantity, DateTime timestamp, DateTime trackingTime)
        {
            BeforeQuantity = beforeQuantity;
            ChangedQuantity = changedQuantity;
            ReceivedQuantity = receivedQuantity;
            ShippedQuantity = shippedQuantity;
            Timestamp = timestamp;
            TrackingTime = trackingTime;
        }
    }
}
