namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemLot
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

        public void Update(string LotId, double quantity, string? purchaseOrderNumber, Location location)
        {

        }

    }
}
