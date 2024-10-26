namespace WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels
{
    public class UpdateFinishedProductReceiptEntryViewModel
    {
        public string ItemId { get; set; }
        public string Unit { get; set; }
        public double RequestedQuantity { get; set; }

        public UpdateFinishedProductReceiptEntryViewModel(string itemId, string unit, double requestedQuantity)
        {
            ItemId = itemId;
            Unit = unit;
            RequestedQuantity = requestedQuantity;
        }
    }
}
