﻿using WMS.Domain.AggregateModels.ItemLotLocationAggregate;
using WMS.Domain.DomainEvents.GoodsReceiptEvents;
using WMS.Domain.DomainEvents.ItemLotEvents;

namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemLot : Entity, IAggregateRoot
    {
        [Key]
        public string LotId { get; set; }

        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsIsolated { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }

        public List<Location> Locations { get; set; }
        public List<ItemLotLocation> ItemLotLocations { get; set; }

#pragma warning disable CS8618
        public ItemLot() { }

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

        public ItemLot(string lotId, double quantity, DateTime timestamp, string itemId)
        {
            LotId = lotId;
            Quantity = quantity;
            Timestamp = timestamp;
            ItemId = itemId;
        }

        public ItemLot(string lotId, double quantity, DateTime timestamp, DateTime productionDate, DateTime expirationDate, bool isIsolated, string itemId)
        {
            LotId = lotId;
            Quantity = quantity;
            Timestamp = timestamp;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            IsIsolated = isIsolated;
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
        public void Confirm(List<ItemLot> itemLots)
        {
            AddDomainEvent(new ItemLotsImportedDomainEvent(itemLots));
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
