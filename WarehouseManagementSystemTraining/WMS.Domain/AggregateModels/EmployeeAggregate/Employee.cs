namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public class Employee : IAggregateRoot
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; }

        public Employee(string employeeId, string employeeName, GoodsReceiptLot goodsReceiptLot)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            GoodsReceiptLot = goodsReceiptLot;
        }

        public Employee(string employeeId)
        {
            EmployeeId = employeeId;
        }




#pragma warning disable CS8618
        private Employee() { }
#pragma warning restore CS8618

    }

    public class EmployeeList
    {
        public string? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
