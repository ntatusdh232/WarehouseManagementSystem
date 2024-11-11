namespace WMS.Api.Application.Commands.ItemLots;

public class IsolatedItemSublotViewModel
{
    public string LocationId { get; set; }
    public double Quantity { get; set; }

    public IsolatedItemSublotViewModel(string locationId, double quantity)
    {
        LocationId = locationId;
        Quantity = quantity;
    }
}
