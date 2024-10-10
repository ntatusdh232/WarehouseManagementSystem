namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public  class FinishedProductInventory
    {
        public string FinishedProductInventoryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public Item Item { get; set; }
        
        public string ItemId { get; set; }
    }
}
