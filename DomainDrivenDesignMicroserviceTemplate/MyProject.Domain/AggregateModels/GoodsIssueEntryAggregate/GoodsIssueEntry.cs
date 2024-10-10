using MyProject.Domain.AggregateModels.GoodsIssueLotAggregate;
using MyProject.Domain.AggregateModels.ItemAggregate;

namespace MyProject.Domain.AggregateModels.GoodsIssueEntryAggregate;

public class GoodsIssueEntry : Entity, IAggregateRoot
{
    public double RequestedQuantity { get; private set; }
    public Item Item { get; private set; }
    public List<GoodsIssueLot> Lots { get; private set; } = new List<GoodsIssueLot>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsIssueEntry()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
