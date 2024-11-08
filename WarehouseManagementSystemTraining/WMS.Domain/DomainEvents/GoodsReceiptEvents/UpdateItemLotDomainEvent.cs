using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace WMS.Domain.DomainEvents.GoodsReceiptEvents;

public class UpdateItemLotDomainEvent : INotification
{
    public string OldItemLotId { get; set; }
    public string? NewItemLotId { get; set; }
    public List<ItemLotLocation>? ItemLotLocations { get; set; }
    public double Quantity {  get; set; }
    public DateTime? ProductionDate { get; set; }
    public DateTime? ExpirationDate {  get; set; }

    public UpdateItemLotDomainEvent(string oldItemLotId, string? newItemLotId, List<ItemLotLocation>? itemLotLocations, double quantity, DateTime? productionDate, DateTime? expirationDate)
    {
        OldItemLotId = oldItemLotId;
        NewItemLotId = newItemLotId;
        ItemLotLocations = itemLotLocations;
        Quantity = quantity;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
    }
}
