namespace WMS.Api.Application.Queries.LotAdjustments;

public class SublotAdjustmentViewModel
{
    public string LocationId { get; set; }
    public double BeforeQuantityPerLocation { get; set; }
    public double AfterQuantityPerLocation { get; set;}

    public SublotAdjustmentViewModel(string locationId, double beforeQuantityPerLocation, double afterQuantityPerLocation)
    {
        LocationId = locationId;
        BeforeQuantityPerLocation = beforeQuantityPerLocation;
        AfterQuantityPerLocation = afterQuantityPerLocation;
    }
}
