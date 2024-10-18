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
        public ICollection<ItemClass> ItemClasses { get; set; }


        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; } 

        public void Update(string unit, double minimumStockLevel, decimal price)
        {

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
