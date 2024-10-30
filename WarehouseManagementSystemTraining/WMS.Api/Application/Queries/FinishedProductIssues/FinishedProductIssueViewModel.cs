namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class FinishedProductIssueViewModel
{
    public string FinishedProductIssueId { get; set; }
    public string Receiver {  get; set; }
    public DateTime Timestamp {  get; set; }
    public EmployeeViewModel Employee { get; set; }
    public List<FinishedProductIssueEntryViewModel> Entries {  get; set; }

    public FinishedProductIssueViewModel(string finishedProductIssueId, string receiver, DateTime timestamp, EmployeeViewModel employee, List<FinishedProductIssueEntryViewModel> entries)
    {
        FinishedProductIssueId = finishedProductIssueId;
        Receiver = receiver;
        Timestamp = timestamp;
        Employee = employee;
        Entries = entries;
    }
}
