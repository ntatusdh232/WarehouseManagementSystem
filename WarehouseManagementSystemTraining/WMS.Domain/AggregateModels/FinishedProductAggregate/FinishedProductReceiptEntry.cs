namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductReceiptEntry
    {
        public string FinishedProductReceiptEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; }
        public string FinishedProductReceiptId { get; set; }

        public FinishedProductReceiptEntry(string finishedProductReceiptEntryId, string purchaseOrderNumber, double quantity, string? note, Item item, string itemId, string finishedProductReceiptId)
        {
            FinishedProductReceiptEntryId = finishedProductReceiptEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
            ItemId = itemId;
            FinishedProductReceiptId = finishedProductReceiptId;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductReceiptEntry() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
