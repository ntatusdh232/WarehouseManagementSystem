using MyProject.Domain.AggregateModels.GoodsIssueLotAggregate;

namespace MyProject.Domain.AggregateModels.GoodsIssueEntryAggregate;

public class GoodsIssueEntry : Entity, IAggregateRoot
{
    public double RequestedQuantity { get; private set; }
    //public Item Item { get; private set; }
    public List<GoodsIssueLot> Lots { get; private set; } = new List<GoodsIssueLot>();

    public GoodsIssueEntry()
    {
    }
}
