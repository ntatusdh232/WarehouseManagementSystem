namespace WMS.Domain.DomainEvents.GoodsReceiptEvents;

public class RemoveItemLotsDomainEvent : INotification
{
    public List<GoodsReceiptLot> ItemLots { get; set; }

    public RemoveItemLotsDomainEvent(List<GoodsReceiptLot> itemLots)
    {
        ItemLots = itemLots;
    }
}
