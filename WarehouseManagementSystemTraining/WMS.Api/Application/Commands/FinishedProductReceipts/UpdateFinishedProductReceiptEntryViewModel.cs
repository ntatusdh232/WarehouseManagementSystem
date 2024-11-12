namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class UpdateFinishedProductReceiptEntryViewModel
    {
        public string ItemId { get; set; }
        public string OldPurchaseOrderNumber { get; set; }
        public string NewPurchaseOrderNumber { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public Item Item { get; set; }

        public UpdateFinishedProductReceiptEntryViewModel(string itemId, string oldPurchaseOrderNumber, string newPurchaseOrderNumber, string unit, double quantity, Item item)
        {
            ItemId = itemId;
            OldPurchaseOrderNumber = oldPurchaseOrderNumber;
            NewPurchaseOrderNumber = newPurchaseOrderNumber;
            Unit = unit;
            Quantity = quantity;
            Item = item;
        }
    }
}

