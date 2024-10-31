namespace WMS.Domain.DomainEvents.GoodsIssueEvents
{
    public class RestoreIssueLotsDomainEvent : INotification
    {
        public List<ItemLot> ExistingItemLots { get; set; }
        public List<ItemLot> RestoredItemLots { get; set; }

        public RestoreIssueLotsDomainEvent(List<ItemLot> existingItemLots, List<ItemLot> restoredItemLots)
        {
            ExistingItemLots = existingItemLots;
            RestoredItemLots = restoredItemLots;
        }
    }
}
