namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceiptLot : IAggregateRoot
    {
        public string GoodsReceiptLotId { get; set; }
        public double Quantity { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsExported { get; set; }
        public string? Note { get; set; }
        public string EmployeeId { get; set; }
        public string ItemId { get; set; }
        public string GoodsReceiptId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
        public List<GoodsReceiptSublot> Sublots { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceiptLot() { }

        public GoodsReceiptLot(string goodsReceiptLotId, double quantity, DateTime? productionDate, DateTime? expirationDate, 
                               bool isExported, string? note, string employeeId, string itemId, string goodsReceiptId, 
                               Employee employee, Item item, List<GoodsReceiptSublot> sublots)
        {
            GoodsReceiptLotId = goodsReceiptLotId;
            Quantity = quantity;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            IsExported = isExported;
            Note = note;
            EmployeeId = employeeId;
            ItemId = itemId;
            GoodsReceiptId = goodsReceiptId;
            Employee = employee;
            Item = item;
            Sublots = sublots;
        }

        public GoodsReceiptLot(string goodsReceiptLotId, string employeeId, double quantity, string? note, string itemId)
        {
            GoodsReceiptLotId = goodsReceiptLotId;
            Quantity = quantity;
            Note = note;
            EmployeeId = employeeId;
            ItemId = itemId;
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
