namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueSublot
    {
        public string GoodsIssueSublotId { get; set; }
        public string LocationId { get; set; }
        public double QuantityPerLocation { get; set; }
        public string GoodsIssueLotId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsIssueSublot() { }
        public GoodsIssueSublot(string goodsIssueSublotId, string locationId, double quantityPerLocation, string goodsIssueLotId)
        {
            GoodsIssueSublotId = goodsIssueSublotId;
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
            GoodsIssueLotId = goodsIssueLotId;
        }

        public GoodsIssueSublot(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    }
}
