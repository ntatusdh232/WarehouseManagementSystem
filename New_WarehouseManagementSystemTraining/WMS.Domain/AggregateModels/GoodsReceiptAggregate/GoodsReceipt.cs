namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceipt
    {
        public String GoodsReceiptId { get; set; }
        public String Supplier { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<GoodsReceiptLot> Lots { get; set; }
        


        public void Update(string lotId, double quantity, double sublotSize, 
                           string purchaseOrderNumber, Location location, 
                           DateTime productionDate, DateTime expirationDate )
        {

        }
        public void AddLot(GoodsReceiptLot goodsReceiptLot)
        {

        }
        public void RemoveLot(string goodsReceiptLotId)
        {

        }
        public void Confirm()
        {

        }

    }
}
