namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public class Employee : IAggregateRoot
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; }


#pragma warning disable CS8618
        private Employee() { }
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

        public Employee(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }


#pragma warning restore CS8618

    }

    public class EmployeeList
    {
        public string? EmployeeId { get; set; }
        public string EmployeeName { get; set; }

#pragma warning disable CS8618
        private EmployeeList() { }

        public EmployeeList(string? employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }
#pragma warning restore CS8618




    }
}
