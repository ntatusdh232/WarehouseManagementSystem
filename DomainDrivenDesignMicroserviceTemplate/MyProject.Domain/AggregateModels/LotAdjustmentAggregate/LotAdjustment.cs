using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.ItemAggregate;

namespace MyProject.Domain.AggregateModels.LotAdjustmentAggregate;
public class LotAdjustment
{
    public string LotId { get; private set; }
    public double BeforeQuantity { get; private set; }
    public double AfterQuantity { get; private set; }
    public bool IsComfirmed { get; private set; }
    public string Note { get; private set; }
    public Item Item { get; private set; }
    public Employee Employee { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public LotAdjustment()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
    public void Update(double quantity, string purchaseOrderNumber)
    {

    }

    public void Confirm()
    {

    }
}
