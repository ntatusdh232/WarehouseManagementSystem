namespace WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels
{
    public class CreateGoodsIssueEntryViewModel
    {
        public string GoodsIssueEntryId { get; set; }
        public double RequestedQuantity { get; set; }
        public Item Item { get; set; }

        public List<GoodsIssueLot> Lots { get; set; }
        public string ItemId { get; set; }
        public string GoodsIssueId { get; set; }

        public CreateGoodsIssueEntryViewModel(string goodsIssueEntryId, double requestedQuantity, Item item, 
                                              List<GoodsIssueLot> lots, string itemId, string goodsIssueId)
        {
            GoodsIssueEntryId = goodsIssueEntryId;
            RequestedQuantity = requestedQuantity;
            Item = item;
            Lots = lots;
            ItemId = itemId;
            GoodsIssueId = goodsIssueId;
        }
    }
}
