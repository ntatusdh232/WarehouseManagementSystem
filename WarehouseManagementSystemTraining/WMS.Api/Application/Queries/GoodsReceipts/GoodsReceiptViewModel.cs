using WMS.Api.Application.Queries.Employees;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GoodsReceiptViewModel
    {
        public String GoodsReceiptId { get; set; }
        public String Supplier { get; set; }
        public DateTime Timestamp { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public List<GoodsReceiptLotViewModel> GoodsReceiptLots { get; set; }

        public GoodsReceiptViewModel(string goodsReceiptId, string supplier, DateTime timestamp, EmployeeViewModel employee, List<GoodsReceiptLotViewModel> goodsReceiptLots)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            Timestamp = timestamp;
            Employee = employee;
            GoodsReceiptLots = goodsReceiptLots;
        }
    }
}
