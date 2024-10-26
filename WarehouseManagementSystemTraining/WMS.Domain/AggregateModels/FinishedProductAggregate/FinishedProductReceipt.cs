namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductReceipt : IAggregateRoot
    {
        public string FinishedProductReceiptId { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<FinishedProductReceiptEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductReceipt() { }
        public FinishedProductReceipt(string finishedProductReceiptId, DateTime timestamp, Employee employee, List<FinishedProductReceiptEntry> entries, string employeeId)
        {
            FinishedProductReceiptId = finishedProductReceiptId;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
            EmployeeId = employeeId;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void AddEntry()
        {

        }

        public void UpdateFinishedProductReceipt(DateTime timestamp, Employee employee,
                                                 List<FinishedProductReceiptEntry> entries)
        {
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
        }

    }
}
