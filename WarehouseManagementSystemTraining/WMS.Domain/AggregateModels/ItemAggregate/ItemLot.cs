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

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ItemLot()
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

        public void Update(double quantity, DateTime timestamp, DateTime? productionDate, DateTime? expirationDate)
        {
            Quantity = quantity;
            Timestamp = timestamp;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

    }
}
