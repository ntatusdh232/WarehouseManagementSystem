namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class Item : IAggregateRoot
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; } 
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public double MinimumStockLevel { get; set; }
        public decimal Price { get; set; }
        public double? PacketSize { get; set; }
        public string? PacketUnit { get; set; }
        public string ItemClassId { get; set; } 
        public ICollection<ItemClass> ItemClasses { get; set; }
        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; }


#pragma warning disable CS8618
        private Item() { }

        public Item(string itemType, string itemId, string itemName, string unit, double minimumStockLevel, 
                    decimal price, double? packetSize, string? packetUnit, string itemClassId, ICollection<ItemClass> itemClasses, 
                    GoodsReceiptLot goodsReceiptLot)
        {
            ItemType = itemType;
            ItemId = itemId;
            ItemName = itemName;
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
            ItemClassId = itemClassId;
            ItemClasses = itemClasses;
            GoodsReceiptLot = goodsReceiptLot;
        }

        public Item(string itemType, string itemId, string itemName, string unit, double minimumStockLevel, 
                    decimal price, double? packetSize, string? packetUnit, string itemClassId)
        {
            ItemType = itemType;
            ItemId = itemId;
            ItemName = itemName;
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
            ItemClassId = itemClassId;
        }

        public Item(string itemId, string itemName, string unit, double minimumStockLevel,
            decimal price, double? packetSize, string? packetUnit, string itemClassId)
        {
            ItemId = itemId;
            ItemName = itemName;
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
            ItemClassId = itemClassId;
        }

#pragma warning restore CS8618

        public void Update(string unit, double minimumStockLevel, decimal price)
        {
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
        }

        public void Update(Item item, string itemClassId)
        {
            ItemType = item.ItemType;
            ItemId = item.ItemId;
            ItemName = item.ItemName;
            Unit = item.Unit;
            MinimumStockLevel = item.MinimumStockLevel;
            Price = item.Price;
            PacketSize = item.PacketSize;
            PacketUnit = item.PacketUnit;
            ItemClassId = itemClassId;

        }
        public void Update(string itemName, string unit, double minimumStockLevel, decimal price, string itemClassId, double? packetSize, string? packetUnit)
        {
            ItemName = itemName;
            Unit = unit;
            MinimumStockLevel = minimumStockLevel;
            Price = price;
            ItemClassId = itemClassId;
            PacketSize = packetSize;
            PacketUnit = packetUnit;
        }

    }

}
