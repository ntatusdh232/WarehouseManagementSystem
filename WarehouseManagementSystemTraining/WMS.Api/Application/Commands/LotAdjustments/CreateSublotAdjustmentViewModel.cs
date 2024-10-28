namespace WMS.Api.Application.Commands.LotAdjustments;

public class CreateSublotAdjustmentViewModel
{
    public string LocationId { get; set; }
    public double NewQuantityPerLocation {  get; set; }

    public CreateSublotAdjustmentViewModel(string locationId, double newQuantityPerLocation)
    {
        LocationId = locationId;
        NewQuantityPerLocation = newQuantityPerLocation;
    }
}
