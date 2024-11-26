namespace WMS.Api.Application.Commands.Items.ItemViewModels
{
    public class CreateItemViewModel
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public double MinimumStockLevel { get; set; }
        public decimal Price { get; set; }
        public string ItemClassId { get; set; }
        public string Unit { get; set; }
        public double? PacketSize { get; set; }
        public string? PacketUnit { get; set; }

        public CreateItemViewModel(string itemType, string itemId, string itemName, double minimumStockLevel, decimal price, string itemClassId, string unit, double? packetSize, string? packetUnit)
        {
            ItemType = itemType;
            ItemId = itemId;
            ItemName = itemName;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            ItemClassId = itemClassId;
            Unit = unit;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
        }
    }
}
