using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductIssueEntry : IAggregateRoot
    {
        [Key]
        public string FinishedProductIssueEntryId { get; set; }

        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }

        [ForeignKey("FinishedProductIssue")]
        public string FinishedProductIssueId { get; set; }
        public FinishedProductIssue FinishedProductIssue { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductIssueEntry() { }
        public FinishedProductIssueEntry(string purchaseOrderNumber, double quantity, string? note, Item item, string itemId)
        {
            FinishedProductIssueEntryId = Guid.NewGuid().ToString();
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
            ItemId = itemId;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
