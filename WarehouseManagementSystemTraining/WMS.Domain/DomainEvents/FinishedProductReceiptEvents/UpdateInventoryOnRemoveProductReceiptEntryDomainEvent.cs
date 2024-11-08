namespace WMS.Domain.DomainEvents.FinishedProductReceiptEvents;

public class UpdateInventoryOnRemoveProductReceiptEntryDomainEvent : INotification
{
    public Item Item { get; set; }
    public string PurchaseOrderNumber { get; set; }
    public double Quantity {  get; set; }

    public UpdateInventoryOnRemoveProductReceiptEntryDomainEvent(Item item, string purchaseOrderNumber, double quantity)
    {
        Item = item;
        PurchaseOrderNumber = purchaseOrderNumber;
        Quantity = quantity;
    }

    public UpdateInventoryOnRemoveProductReceiptEntryDomainEvent(Item item, string purchaseOrderNumber)
    {
        Item = item;
        PurchaseOrderNumber = purchaseOrderNumber;
    }
}
