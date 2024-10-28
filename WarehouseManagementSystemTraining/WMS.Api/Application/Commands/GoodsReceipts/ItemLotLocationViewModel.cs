namespace WMS.Api.Application.Commands.GoodsReceipts;

public class ItemLotLocationViewModel
{
    public string LocationId { get; set; }
    public double QuantityPerLocation {  get; set; }

    public ItemLotLocationViewModel(string locationId, double quantityPerLocation)
    {
        LocationId = locationId;
        QuantityPerLocation = quantityPerLocation;
    }
}
