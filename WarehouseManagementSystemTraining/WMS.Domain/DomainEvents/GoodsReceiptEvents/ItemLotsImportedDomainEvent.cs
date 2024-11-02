
namespace WMS.Domain.DomainEvents.GoodsReceiptEvents;

public class ItemLotsImportedDomainEvent : INotification
{
    public List<ItemLot> ItemLots { get; set; }

    public ItemLotsImportedDomainEvent(List<ItemLot> itemLots)
    {
        ItemLots = itemLots;
    }
}
