namespace WMS.Api.Application.Commands.IsolatedItemLots.IsolatedItemLotViewModels
{
    public class UnisolatedItemSublotViewModel
    {
        public string LocationId { get; set; }
        public double QuantityPerLocation { get; set; }

        public UnisolatedItemSublotViewModel(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }
    }
}
