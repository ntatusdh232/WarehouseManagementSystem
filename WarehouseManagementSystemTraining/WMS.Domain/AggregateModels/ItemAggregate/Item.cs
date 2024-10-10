using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class Item
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; } // Sửa lại tên thuộc tính để sử dụng chữ hoa cho "Id"
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public double MinimumStockLevel { get; set; }
        public decimal Price { get; set; }
        public double? PacketSize { get; set; }
        public string? PacketUnit { get; set; }
        public ICollection<ItemClass> ItemClasses { get; set; }

        // Nếu bạn muốn mối quan hệ một-một
        public virtual GoodsReceiptLot GoodsReceiptLot { get; set; } // Chỉ có một GoodsReceiptLot

        public void Update(string unit, double minimumStockLevel, decimal price)
        {
            // Cập nhật thông tin
        }
    }
}
