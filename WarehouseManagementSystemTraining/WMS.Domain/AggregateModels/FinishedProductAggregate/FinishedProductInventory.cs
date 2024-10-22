namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public  class FinishedProductInventory : IAggregateRoot
    {
        public string FinishedProductInventoryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; }

        public void UpdateFinishedProductInventory(string purchaseOrderNumber, double quantity, DateTime timestamp, Item item)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Timestamp = timestamp;
            Item = item;

        }

    }
}
