namespace WMS.Domain.DomainEvents.FinishedProductReceiptEvents;

public class UpdateInventoryOnModifyProductReceiptEntryDomainEvent : INotification
{
    public string OldPurchaseOrderNumber {  get; set; }
    public string NewPurchaseOrderNumber { get; set; }
    public double OldQuantity {  get; set; }
    public double NewQuantity { get; set; }
    public DateTime Timestamp {  get; set; }
    public Item Item {  get; set; }

    public UpdateInventoryOnModifyProductReceiptEntryDomainEvent(string oldPurchaseOrderNumber, string newPurchaseOrderNumber, double oldQuantity, double newQuantity, DateTime timestamp, Item item)
    {
        OldPurchaseOrderNumber = oldPurchaseOrderNumber;
        NewPurchaseOrderNumber = newPurchaseOrderNumber;
        OldQuantity = oldQuantity;
        NewQuantity = newQuantity;
        Timestamp = timestamp;
        Item = item;
    }
}
