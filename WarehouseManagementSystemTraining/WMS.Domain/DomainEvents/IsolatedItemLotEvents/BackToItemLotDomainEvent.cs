using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace WMS.Domain.DomainEvents.IsolatedItemLotEvents
{
    public class BackToItemLotDomainEvent : INotification
    {
        public ItemLot ItemLot { get; set; }
        public List<ItemLotLocation> UnisolatedItemLotLocations { get; set; }
        public double UnisolatedQuantity { get; set; }

        public BackToItemLotDomainEvent(ItemLot itemLot, List<ItemLotLocation> itemLotLocation, double unisolatedQuantity)
        {
            ItemLot = itemLot;
            UnisolatedItemLotLocations = itemLotLocation;
            UnisolatedQuantity = unisolatedQuantity;
        }
    }
}
