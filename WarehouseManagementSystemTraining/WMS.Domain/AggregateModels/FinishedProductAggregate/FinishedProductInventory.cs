namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public  class FinishedProductInventory : IAggregateRoot
    {
        [Key]
        public string FinishedProductInventoryId { get; set; }

        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductInventory() { }

        public FinishedProductInventory(string finishedProductInventoryId, string purchaseOrderNumber, double quantity, DateTime timestamp, Item item, string itemId)
        {
            FinishedProductInventoryId = finishedProductInventoryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Timestamp = timestamp;
            Item = item;
            ItemId = itemId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void UpdateFinishedProductInventory(string purchaseOrderNumber, double quantity, DateTime timestamp, Item item)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Timestamp = timestamp;
            Item = item;

        }

    }
}
