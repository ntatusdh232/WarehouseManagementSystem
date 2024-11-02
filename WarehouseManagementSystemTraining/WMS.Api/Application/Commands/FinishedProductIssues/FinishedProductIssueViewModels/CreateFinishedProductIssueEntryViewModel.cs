namespace WMS.Api.Application.Commands.FinishedProductIssues.FinishedProductIssueViewModels
{
    public class CreateFinishedProductIssueEntryViewModel
    {
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string ItemId { get; set; }
        public string? Note { get; set; }

        public CreateFinishedProductIssueEntryViewModel(string purchaseOrderNumber, double quantity, string itemId, string? note)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            ItemId = itemId;
            Note = note;
        }
    }
}
