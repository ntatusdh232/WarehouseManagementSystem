namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductIssueEntry : IAggregateRoot
    {
        public string FinishedProductIssueEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; } 
        public string FinishedProductIssueId { get; set; }
    }
}
