namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class RemoveFinishedProductEntryViewModel
{
    public string ItemId {  get; set; }
    public string PurchaseOrderNumber {  get; set; }
    public string Unit {  get; set; }

    public RemoveFinishedProductEntryViewModel(string itemId, string purchaseOrderNumber, string unit)
    {
        ItemId = itemId;
        PurchaseOrderNumber = purchaseOrderNumber;
        Unit = unit;
    }
}
