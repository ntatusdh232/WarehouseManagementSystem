namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceiptSublot
    {
        public string GoodsReceiptSublotId { get; set; }
        public string LocationId { get; set; }
        public double QuantityPerLocation { get; set; }
        public string GoodsReceiptLotId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceiptSublot() { }

        public GoodsReceiptSublot(string goodsReceiptSublotId, string locationId, double quantityPerLocation, string goodsReceiptLotId)
        {
            GoodsReceiptSublotId = goodsReceiptSublotId;
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
            GoodsReceiptLotId = goodsReceiptLotId;
        }

        public GoodsReceiptSublot(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
