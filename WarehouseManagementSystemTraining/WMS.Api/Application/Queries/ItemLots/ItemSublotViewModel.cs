namespace WMS.Api.Application.Queries.ItemLots;

public class ItemSublotViewModel
{
    public string LocationId { get; set; }
    public double QuantityPerLocation {  get; set; }

    public ItemSublotViewModel(string locationId, double quantityPerLocation)
    {
        LocationId = locationId;
        QuantityPerLocation = quantityPerLocation;
    }
}
