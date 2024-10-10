namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueLot
    {
        public string GoodsIssueLotId { get; set; } 
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public string EmployeeId { get; set; }
        public List<GoodsIssueSublot> Sublots { get; set; }
        public virtual Employee Employee { get; set; }


    }
}

