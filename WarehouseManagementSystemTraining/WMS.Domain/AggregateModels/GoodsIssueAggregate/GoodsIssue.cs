namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssue
    {
        public string GoodsIssueId { get; set; }
        public string? Receiver { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<GoodsIssueEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

        public void AddEntry(GoodsIssueEntry goodsIssueEntry)
        {

        }
        public void SetQuantity(string itemId, double quantity)
        {

        }
        public void AddLot(string itemId, GoodsIssueLot goodsIssueLot)
        {

        }
        
        public void Confirm()
        {

        }

    }
}
