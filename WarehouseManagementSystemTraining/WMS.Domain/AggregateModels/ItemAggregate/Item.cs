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


    }

    public class ItemList : IAggregateRoot
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public double MinimumStockLevel { get; set; }
        public decimal Price { get; set; }
        public double? PacketSize { get; set; }
        public string? PacketUnit { get; set; }
    }

}
