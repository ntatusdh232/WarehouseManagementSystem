namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GoodsReceiptLotViewModel
    {
        public string GoodsReceiptLotId { get; set; }
        public double Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Note { get; set; }
        public bool IsExported { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public ItemViewModel Item { get; set; }
        public List<GoodsReceiptSublotViewModel> GoodsReceiptSublots { get; set; }

        public GoodsReceiptLotViewModel(string goodsReceiptLotId, double quantity, DateTime productionDate, DateTime expirationDate, 
                                        string note, bool isExported, EmployeeViewModel employee, ItemViewModel item, 
                                        List<GoodsReceiptSublotViewModel> goodsReceiptSublots)
        {
            GoodsReceiptLotId = goodsReceiptLotId;
            Quantity = quantity;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Note = note;
            IsExported = isExported;
            Employee = employee;
            Item = item;
            GoodsReceiptSublots = goodsReceiptSublots;
        }

        public void UpdateIsExported()
        {
           IsExported = true;
        }

    }
}
