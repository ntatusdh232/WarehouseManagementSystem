namespace WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels
{
    public class UpdateGoodsIssueEntryViewModel
    {        
        public string ItemId { get; set; }
        public string Unit { get; set; }
        public double RequestedQuantity { get; set; }

        public UpdateGoodsIssueEntryViewModel(string itemId, string unit, double requestedQuantity)
        {
            ItemId = itemId;
            Unit = unit;
            RequestedQuantity = requestedQuantity;
        }

    }
}
