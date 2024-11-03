namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class CreateFinishedProductReceiptEntryViewModel
{
    public string PurchaseOrderNumber { get; set; }
    public double Quantity { get; set; }
    public string ItemId { get; set; }
    public string Unit { get; set; }
    public string Note { get; set; }

    public CreateFinishedProductReceiptEntryViewModel(string purchaseOrderNumber, double quantity, string itemId, string unit, string note)
    {
        PurchaseOrderNumber = purchaseOrderNumber;
        Quantity = quantity;
        ItemId = itemId;
        Unit = unit;
        Note = note;
    }
}
