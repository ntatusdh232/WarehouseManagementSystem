namespace WMS.Domain.DomainEvents.GoodsIssueEvents
{
    public class ItemLotsExportedDomainEvent : INotification
    {
        public List<ItemLot> ItemLots;

        public ItemLotsExportedDomainEvent(List<ItemLot> itemLots)
        {
            ItemLots = itemLots;
        }
    }
}
