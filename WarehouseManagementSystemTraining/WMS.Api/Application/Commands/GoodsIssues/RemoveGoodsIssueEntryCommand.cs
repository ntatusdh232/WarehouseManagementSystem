namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class RemoveGoodsIssueEntryCommand : IRequest<bool>
    {
        public string GoodsIssueId { get; set; }
        public string ItemId { get; set; }
        public string Unit { get; set; }

        public RemoveGoodsIssueEntryCommand(string goodsIssueId, string itemId, string unit)
        {
            GoodsIssueId = goodsIssueId;
            ItemId = itemId;
            Unit = unit;
        }
    }
}
