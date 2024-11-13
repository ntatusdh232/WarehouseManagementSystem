using WMS.Domain.AggregateModels.ItemLotLocationAggregate;
using WMS.Domain.DomainEvents.ItemLotEvents;

namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemLot : Entity, IAggregateRoot
    {
        public string LotId { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsIsolated { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; }
        public List<Location> Locations { get; set; }
        public List<ItemLotLocation> ItemLotLocations { get; set; }

#pragma warning disable CS8618
        private ItemLot() { }

        public ItemLot(string lotId, double quantity, DateTime timestamp, DateTime productionDate, DateTime expirationDate, bool isIsolated, Item item, string itemId, List<Location> locations, List<ItemLotLocation> itemLotLocations)
        {
            LotId = lotId;
            Quantity = quantity;
            Timestamp = timestamp;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            IsIsolated = isIsolated;
            Item = item;
            ItemId = itemId;
            Locations = locations;
            ItemLotLocations = itemLotLocations;
        }

        public ItemLot(string lotId, double quantity, string itemId)
        {
            LotId = lotId;
            Quantity = quantity;
            ItemId = itemId;
        }

        public ItemLot(double quantity, Item item, string itemId)
        {
            Quantity = quantity;
            Item = item;
            ItemId = itemId;
        }

#pragma warning restore CS8618

        public void Update(double quantity, DateTime timestamp, DateTime productionDate, DateTime expirationDate)
        {
            Quantity = quantity;
            Timestamp = timestamp;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

        // Hàm Confirm() cho dispatchedItemLots
        public void Confirm()
        {

        }

        public void Unisolated()
        {
            IsIsolated = false;
        }
        public void Isolate(double isolatedQuantity)
        {
            IsIsolated = true;
            Quantity -= isolatedQuantity;
            AddDomainEvent(new IsolateItemLotsDomainEvent(LotId, isolatedQuantity, ProductionDate, ExpirationDate, ItemId));
        }
    }
}
