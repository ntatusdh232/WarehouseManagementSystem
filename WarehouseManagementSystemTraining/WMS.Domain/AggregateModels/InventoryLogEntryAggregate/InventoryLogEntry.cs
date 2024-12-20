﻿namespace WMS.Domain.AggregateModels.InventoryLogEntryAggregate
{
    public class InventoryLogEntry : IAggregateRoot
    {
        [Key]
        public string Id { get; set; }

        public string ItemLotId { get; set; }
        public double BeforeQuantity { get; set; } 
        public double ChangedQuantity { get; set; }
        public double ReceivedQuantity { get; set; }
        public double ShippedQuantity { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime TrackingTime { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }


#pragma warning disable CS8618 
        private InventoryLogEntry(){}

        public InventoryLogEntry(string itemLotId, double beforeQuantity, double changedQuantity, double receivedQuantity, double shippedQuantity, DateTime timestamp, DateTime trackingTime, string itemId)
        {
            ItemLotId = itemLotId;
            BeforeQuantity = beforeQuantity;
            ChangedQuantity = changedQuantity;
            ReceivedQuantity = receivedQuantity;
            ShippedQuantity = shippedQuantity;
            Timestamp = timestamp;
            TrackingTime = trackingTime;
            ItemId = itemId;
        }




#pragma warning restore CS8618


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
