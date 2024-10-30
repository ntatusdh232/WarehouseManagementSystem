namespace WMS.Api.Application.Queries.GoodsIssues;

public class GoodsIssueViewModel
{
    public string GoodsIssueId { get; set; }
    public string Receiver {  get; set; }
    public DateTime Timestamp {  get; set; }
    public EmployeeViewModel Employee {  get; set; }
    public List<GoodsIssueEntryViewModel> Entries {  get; set; }

    public GoodsIssueViewModel(string goodsIssueId, string receiver, DateTime timestamp, EmployeeViewModel employee, List<GoodsIssueEntryViewModel> entries)
    {
        GoodsIssueId = goodsIssueId;
        Receiver = receiver;
        Timestamp = timestamp;
        Employee = employee;
        Entries = entries;
    }
}
