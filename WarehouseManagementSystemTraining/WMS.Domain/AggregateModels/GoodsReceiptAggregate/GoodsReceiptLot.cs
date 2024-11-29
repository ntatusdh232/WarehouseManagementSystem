namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceiptLot : IAggregateRoot
    {
        [Key]
        public string GoodsReceiptLotId { get; set; }

        public double Quantity { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsExported { get; set; }
        public string? Note { get; set; }

        public List<GoodsReceiptSublot> Sublots { get; set; }

        [ForeignKey("GoodsReceipt")]
        public string GoodsReceiptId { get; set; }
        public GoodsReceipt GoodsReceipt { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceiptLot() { }


        public GoodsReceiptLot(string goodsReceiptLotId, double quantity, string? note, string goodsReceiptId, Employee employee, Item item)
        {
            GoodsReceiptLotId = goodsReceiptLotId;
            Quantity = quantity;
            Employee = employee;
            Item = item;
            Note = note;
            GoodsReceiptId = goodsReceiptId;
            Sublots = new List<GoodsReceiptSublot>();

        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string lotId, double quantity, DateTime? productionDate, DateTime? expirationDate,  string? note, List<GoodsReceiptSublot> sublots)
        {
            GoodsReceiptLotId = lotId;
            Quantity = quantity;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Note = note;
            Sublots = sublots;
        }
    }
}
