namespace WMS.Domain.DomainEvents.FinishedProductIssueEvents
{
    public class UpdateInventoryOnRemoveProductIssueEntryDomainEvent : INotification
    {
        public Item Item { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }

        public UpdateInventoryOnRemoveProductIssueEntryDomainEvent(Item item, string purchaseOrderNumber, double quantity)
        {
            Item = item;
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
        }
    }
}
