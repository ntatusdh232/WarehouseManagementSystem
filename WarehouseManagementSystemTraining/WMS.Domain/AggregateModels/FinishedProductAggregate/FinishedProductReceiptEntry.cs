﻿namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductReceiptEntry
    {
        [Key]
        public string FinishedProductReceiptEntryId { get; set; }

        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("FinishedProductReceipt")]
        public string FinishedProductReceiptId { get; set; }
        public FinishedProductReceipt FinishedProductReceipt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductReceiptEntry() { }

        public FinishedProductReceiptEntry(string purchaseOrderNumber, double quantity, string note, Item item, string itemId)
        {
            FinishedProductReceiptEntryId = Guid.NewGuid().ToString();
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
            ItemId = itemId;
        }

        public FinishedProductReceiptEntry(string purchaseOrderNumber, double quantity, string note, string finishedProductReceiptId, Item item)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
            FinishedProductReceiptId = finishedProductReceiptId;
        }

        public void UpdateEntry(string purchaseOrderNumber, double quantity, Item item)
        {
            FinishedProductReceiptEntryId = this.FinishedProductReceiptEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Item = item;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
