namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductIssue
    {
        public string FinishedProductIssueId { get; set; }
        public string? Receiver { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<FinishedProductIssueEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

         public void AddEntry()
        {

        }

    }
}
