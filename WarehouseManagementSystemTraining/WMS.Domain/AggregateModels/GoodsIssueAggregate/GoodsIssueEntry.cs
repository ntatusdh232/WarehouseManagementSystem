namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueEntry
    {
        public string GoodsIssueEntryId { get; set; }
        public double RequestedQuantity { get; set; }
        public Item Item { get; set; }

        public List<GoodsIssueLot> Lots { get; set; }
        public string ItemId { get; set; } 
    }
}
