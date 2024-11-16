namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceiptSublot
    {
        [Key]
        public string GoodsReceiptSublotId { get; set; }

        public string LocationId { get; set; }
        public double QuantityPerLocation { get; set; }

        [ForeignKey("GoodsReceiptLot")]
        public string GoodsReceiptLotId { get; set; }
        public GoodsReceiptLot GoodsReceiptLot { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceiptSublot() { }

        public GoodsReceiptSublot(string goodsReceiptSublotId, string locationId, double quantityPerLocation, string goodsReceiptLotId)
        {
            GoodsReceiptSublotId = goodsReceiptSublotId;
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
            GoodsReceiptLotId = goodsReceiptLotId;
        }

        public GoodsReceiptSublot(string locationId, double quantityPerLocation, string goodsReceiptLotId)
        { 
            GoodsReceiptSublotId = Guid.NewGuid().ToString();
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
            GoodsReceiptLotId = goodsReceiptLotId;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
