using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.GoodsReceiptSublotAggregate;
using MyProject.Domain.AggregateModels.ItemAggregate;

namespace MyProject.Domain.AggregateModels.GoodsReceiptLotAggregate;

public class GoodsReceiptLot : Entity, IAggregateRoot
{
    public string GoodsReceiptLotId { get; private set; }
    public double Quantity { get; private set; }
    public DateTime? ProductionDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public string? Note {  get; private set; }
    public Employee Employee { get; private set; }
    public Item Item { get; private set; }
    public List<GoodsReceiptSublot> Sublots { get; private set; } = new List<GoodsReceiptSublot>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsReceiptLot()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public void Update(double quantity, double sublotSize, string? purchaseOrderNumber, string LocationId, DateTime productionDate, DateTime expirationDate)
    {

    }
}
