namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceiptLot
    {
        public string GoodsReceiptLotId { get; set; }
        public double Quantity { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Note { get; set; }
        public string EmployeeId { get; set; }
        public string ItemId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
        public List<GoodsReceiptSublot> Sublots { get; set; }

        public void Update(double quantity, double sublotSize, string? purchaseOrderNumber,
                           string locationId, DateTime productionDate, DateTime expirationDate)
        {
            // Cập nhật thông tin
        }
    }
}
