namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GoodsReceiptSublotViewModel
    {
        public string LocationId { get; set; }
        public double QuantityPerLocation { get; set; }

        public GoodsReceiptSublotViewModel(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }
    }
}
