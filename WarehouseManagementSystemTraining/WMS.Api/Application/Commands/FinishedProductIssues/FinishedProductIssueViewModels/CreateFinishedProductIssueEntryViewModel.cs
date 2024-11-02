namespace WMS.Api.Application.Commands.FinishedProductIssues.FinishedProductIssueViewModels
{
    public class CreateFinishedProductIssueEntryViewModel
    {
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string ItemId { get; set; }
        public string Unit { get; set; }
        public string? Note { get; set; }

        public CreateFinishedProductIssueEntryViewModel(string purchaseOrderNumber, double quantity, string itemId, string unit, string? note)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            ItemId = itemId;
            Unit = unit;
            Note = note;
        }
    }
}
