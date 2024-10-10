using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.GoodsIssueEntryAggregate;
using MyProject.Domain.AggregateModels.GoodsIssueLotAggregate;

namespace MyProject.Domain.AggregateModels.GoodsIssueAggregate;

public class GoodsIssue : Entity, IAggregateRoot
{
    public string GoodsIssueId { get; private set; }
    public string? Receiver {  get; private set; }
    public DateTime Timestamp { get; private set; }
    public Employee Employee { get; private set; }
    public List<GoodsIssueEntry> Entries { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsIssue()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
    public void AddEntry(GoodsIssueEntry goodsissueEntry)
    { }

    public void SetQuantity(string itemId, double quantity)
    { }

    public void AddLot(string itemId, GoodsIssueLot goodsissueLot)
    { }

    public void Confirm()
    { }
}
