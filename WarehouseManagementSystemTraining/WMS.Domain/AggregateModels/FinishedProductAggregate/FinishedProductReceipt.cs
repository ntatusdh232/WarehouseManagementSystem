namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductReceipt
    {
        public string FinishedProductReceiptId { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<FinishedProductReceiptEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

        public void AddEntry()
        {

        }
    }
}
