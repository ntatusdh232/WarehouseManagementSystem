namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class LotAdjustment : IAggregateRoot
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


#pragma warning disable CS8618
        private LotAdjustment() { }

        public LotAdjustment(string lotId, double beforeQuantity, double afterQuantity, bool isConfirmed, string note, 
                             Item item, Employee employee, string itemId, string employeeId)
        {
            LotId = lotId;
            BeforeQuantity = beforeQuantity;
            AfterQuantity = afterQuantity;
            IsConfirmed = isConfirmed;
            Note = note;
            Item = item;
            Employee = employee;
            ItemId = itemId;
            EmployeeId = employeeId;
        }

#pragma warning restore CS8618

        public void Update(double quantity, string purchaseOrderNumber) 
        {
            AfterQuantity = quantity;
            Note = purchaseOrderNumber;
        }
        public void Confirm()
        {
            
        }
    }

}
