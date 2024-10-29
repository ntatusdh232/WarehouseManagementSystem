namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class FinishedProductReceiptEntryViewModel
    {
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }
        public ItemViewModel Item { get; set; }

        public FinishedProductReceiptEntryViewModel(string purchaseOrderNumber, double quantity, string note, ItemViewModel item)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
        }
    }
}
