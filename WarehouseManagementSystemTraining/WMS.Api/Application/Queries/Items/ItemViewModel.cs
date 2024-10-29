namespace WMS.Api.Application.Queries.Items
{
    public class ItemViewModel
    {
        public string ItemId { get; set; }
        public string ItemClassId { get; set; }
        public string ItemName { get; set; }
        public string Unit {  get; set; }
        public double MinimumStockLevel { get; set; }
        public decimal? Price { get; set; }
        public double? PacketSize { get; set; }
        public string PacketUnit { get; set; }

        public ItemViewModel(string itemId, string itemClassId, string itemName, string unit, double minimumStockLevel, decimal? price, double? packetSize, string packetUnit)
        {
            ItemId = itemId;
            ItemClassId = itemClassId;
            ItemName = itemName;
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
        }
    }
}
