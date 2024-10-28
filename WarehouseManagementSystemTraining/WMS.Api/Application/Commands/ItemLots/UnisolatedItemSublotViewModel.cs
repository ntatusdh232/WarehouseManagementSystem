namespace WMS.Api.Application.Commands.ItemLots;

public class UnisolatedItemSublotViewModel
{
    public string LocationId { get; set; }
    public double Quantity {  get; set; }

    public UnisolatedItemSublotViewModel(string locationId, double quantity)
    {
        LocationId = locationId;
        Quantity = quantity;
    }
}
