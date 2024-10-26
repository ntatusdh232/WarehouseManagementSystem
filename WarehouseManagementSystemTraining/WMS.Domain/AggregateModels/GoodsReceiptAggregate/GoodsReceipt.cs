using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceipt : IAggregateRoot
    {
        public String GoodsReceiptId { get; set; }
        public String Supplier { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<GoodsReceiptLot> Lots { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceipt() { }

        public GoodsReceipt(string goodsReceiptId, string supplier, DateTime timestamp, 
                            Employee employee, string employeeId, List<GoodsReceiptLot> lots)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            Timestamp = timestamp;
            Employee = employee;
            EmployeeId = employeeId;
            Lots = lots;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.




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

        public void UpdateGoodsReceipt(String goodsReceiptId, String supplier, DateTime timestamp,
                                       Employee employee, List<GoodsReceiptLot> lots)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            Timestamp = Timestamp;
            Employee = Employee;
            Lots = Lots;
        }

    }
}
