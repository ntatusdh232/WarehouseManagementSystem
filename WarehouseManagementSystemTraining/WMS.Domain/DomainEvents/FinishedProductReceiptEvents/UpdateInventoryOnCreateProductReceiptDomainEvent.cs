namespace WMS.Domain.DomainEvents.FinishedProductReceiptEvents;

public class UpdateInventoryOnCreateProductReceiptDomainEvent : INotification
{
    public string PurchaseOrderNumber {  get; set; }
    public double Quantity {  get; set; }
    public DateTime Timestamp {  get; set; }
    public Item Item { get; set; }

    public UpdateInventoryOnCreateProductReceiptDomainEvent(string purchaseOrderNumber, double quantity, DateTime timestamp, Item item)
    {
        PurchaseOrderNumber = purchaseOrderNumber;
        Quantity = quantity;
        Timestamp = timestamp;
        Item = item;
    }
}
