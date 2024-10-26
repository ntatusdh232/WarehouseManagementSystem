namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueEntry : IAggregateRoot
    {
        public string GoodsIssueEntryId { get; set; }
        public double RequestedQuantity { get; set; }
        public Item Item { get; set; }

        public List<GoodsIssueLot> Lots { get; set; }
        public string ItemId { get; set; } 
        public string GoodsIssueId { get; set; }
    }
}
