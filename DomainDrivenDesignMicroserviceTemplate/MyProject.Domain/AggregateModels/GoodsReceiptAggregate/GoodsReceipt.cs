using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.GoodsReceiptLotAggregate;
using MyProject.Domain.AggregateModels.LocationAggregate;

namespace MyProject.Domain.AggregateModels.GoodsReceiptAggregate;

public class GoodsReceipt : Entity, IAggregateRoot
{
    public string GoodsReceiptId { get; private set; }
    public string Supplier {  get; private set; }
    public DateTime Timestamp { get; private set; }
    public Employee Employee { get; private set; }
    public List<GoodsReceiptLot> Lots { get; private set; } = new List<GoodsReceiptLot>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public GoodsReceipt()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
    public void Update(string lotId, double quantity, double sublotSize, string purchaseOrderNumber, Location location, DateTime productionDate, DateTime expirationDate)
    {

    }
    public void AddLot(GoodsReceiptLot goodsReceiptLot)
    {

    }
    public void RemoveLot(string goodsReceiptLotId)
    {

    }
    public void Confirm()
    {

    }
}
