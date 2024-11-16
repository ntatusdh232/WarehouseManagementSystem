using DocumentFormat.OpenXml.InkML;

namespace WMS.Domain.DomainEvents.InventoryLogEntryEvents
{
    public class InventoryLogEntryAddedDomainEvent : INotification
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

        public InventoryLogEntryAddedDomainEvent(string itemLotId, double changedQuantity, 
                                                 double receivedQuantity, double shippedQuantity, string itemId, DateTime timestamp)
        {
            ItemLotId = itemLotId;
            ChangedQuantity = changedQuantity;
            ReceivedQuantity = receivedQuantity;
            ShippedQuantity = shippedQuantity;
            Timestamp = timestamp;
            ItemId = itemId;
        }



    }
}
