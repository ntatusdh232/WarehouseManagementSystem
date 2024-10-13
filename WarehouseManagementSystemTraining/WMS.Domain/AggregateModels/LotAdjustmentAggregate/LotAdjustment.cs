namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class LotAdjustment
    {
        public string LotId { get; set; }
        public double BeforeQuantity { get; set; }
        public double AfterQuantity { get; set; }
        public bool IsConfirmed { get; set; }
        public string Note { get; set; }
        public Item Item { get; set; }
        public Employee Employee { get; set; }
        public string ItemId { get; set; }
        public string EmployeeId { get; set; }
        public void Update(double quantity, string purchaseOrderNumber) 
        {
            
        }
        public void Confirm()
        {
            
        }
    }
}
