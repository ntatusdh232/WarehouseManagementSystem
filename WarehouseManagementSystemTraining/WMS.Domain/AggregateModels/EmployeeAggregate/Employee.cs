namespace WMS.Domain.AggregateModels.EmployeeAggregate
{
    public class Employee : IAggregateRoot
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; } // Chỉ có một GoodsReceiptLot
    }

    public class EmployeeList
    {
        public string? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
