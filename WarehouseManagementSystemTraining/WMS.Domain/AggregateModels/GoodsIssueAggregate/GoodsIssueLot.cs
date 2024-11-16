namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueLot : IAggregateRoot
    {
        [Key]
        public string GoodsIssueLotId { get; set; } 

        public double Quantity { get; set; }
        public string? Note { get; set; }

        public List<GoodsIssueSublot> Sublots { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("GoodsIssueEntry")]
        public string GoodsIssueEntryId { get; set; }
        public GoodsIssueEntry GoodsIssueEntry { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsIssueLot() { }

        public GoodsIssueLot(string goodsIssueLotId, double quantity, string? note, string employeeId, List<GoodsIssueSublot> sublots)
        {
            GoodsIssueLotId = goodsIssueLotId;
            Quantity = quantity;
            Note = note;
            EmployeeId = employeeId;
            Sublots = sublots;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}

