namespace WMS.Api.Application.Commands.FinishedProductIssues.FinishedProductIssueViewModels
{
    public class CreateFinishedProductIssueEntryViewModel
    {
        public string FinishedProductIssueEntryId { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; }
        public string FinishedProductIssueId { get; set; }

        public CreateFinishedProductIssueEntryViewModel(string finishedProductIssueEntryId, string purchaseOrderNumber, double quantity, 
                                                        string? note, Item item, string itemId, string finishedProductIssueId)
        {
            FinishedProductIssueEntryId = finishedProductIssueEntryId;
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            Item = item;
            ItemId = itemId;
            FinishedProductIssueId = finishedProductIssueId;
        }

    }
}
