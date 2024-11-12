
namespace WMS.Domain.DomainEvents.ItemLotEvents;

public class IsolateItemLotsDomainEvent : INotification
{
    public string ItemLotId { get; set; }
    public double Quantity {  get; set; }
    public DateTime ProductionDate {  get; set; }
    public DateTime ExpirationDate { get; set; }
    public int ItemId { get; set; }

    public IsolateItemLotsDomainEvent(string itemLotId, double quantity, DateTime productionDate, DateTime expirationDate, int itemId)
    {
        ItemLotId = itemLotId;
        Quantity = quantity;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
        ItemId = itemId;
    }
}
