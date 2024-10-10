using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.GoodsIssueSublotAggregate;

namespace MyProject.Domain.AggregateModels.GoodsIssueLotAggregate;

public class GoodsIssueLot : Entity, IAggregateRoot
{
    public string GoodsIssueLotId { get; private set; }
    public double Quantity { get; private set; }
    public string? Note {  get; private set; }
    public Employee Employee { get; private set; }
    public List<GoodsIssueSublot> Sublots { get; private set; } = new List<GoodsIssueSublot>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsIssueLot()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
