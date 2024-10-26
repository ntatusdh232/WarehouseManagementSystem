namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemLot : IAggregateRoot
    {
        public string LotId { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsIsolated { get; set; }
        public Item Item { get; set; }
        public string ItemId { get; set; }
        public List<Location> Locations { get; set; }

#pragma warning disable CS8618
        private ItemLot() { }

        public ItemLot(string lotId, double quantity, DateTime timestamp, DateTime? productionDate, DateTime? expirationDate, 
                       bool isIsolated, Item item, string itemId, List<Location> locations)
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
        }

#pragma warning restore CS8618

        public void Update(double quantity, DateTime timestamp, DateTime? productionDate, DateTime? expirationDate)
        {
            Quantity = quantity;
            Timestamp = timestamp;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

    }
}
