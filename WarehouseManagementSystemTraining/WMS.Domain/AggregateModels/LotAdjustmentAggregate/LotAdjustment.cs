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
        public List<SublotAdjustment> SublotAdjustments { get; set; }
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
        public LotAdjustment(string lotId, string itemId, double afterQuantity, string note, Item item, Employee employee, string employeeId)
        {
            LotId = lotId;
            ItemId = itemId;
            AfterQuantity = afterQuantity;
            Note = note;
            Item = item;
            Employee = employee;
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

        public void Update(double quantity)
        {
            AfterQuantity = quantity;
        }
         public void AddSublot(string locationId, double beforeQuantity, double afterQuantity)
    {
        var sublot = new SublotAdjustment(locationId, beforeQuantity, afterQuantity);
        SublotAdjustments.Add(sublot);
    }

    }

}
