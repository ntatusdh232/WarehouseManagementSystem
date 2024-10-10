
namespace MyProject.Domain.AggregateModels.GoodsReceiptSublotAggregate;

public class GoodsReceiptSublot : Entity, IAggregateRoot
{
    public string LocationId { get; private set; }
    public double QuantityPerLocation { get; private set; }

    public GoodsReceiptSublot(string locationId, double quantityPerLocation)
    {
        LocationId = locationId;
        QuantityPerLocation = quantityPerLocation;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsReceiptSublot()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
