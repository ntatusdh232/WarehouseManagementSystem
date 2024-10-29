namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class FinishedProductReceiptViewModel
    {
        public string FinishedProductReceiptId { get; set; }
        public DateTime Timestamp { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public List<FinishedProductReceiptEntryViewModel> Entries { get; set; }

        public FinishedProductReceiptViewModel(string finishedProductReceiptId, DateTime timestamp, EmployeeViewModel employee, List<FinishedProductReceiptEntryViewModel> entries)
        {
            FinishedProductReceiptId = finishedProductReceiptId;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
        }
    }
}
