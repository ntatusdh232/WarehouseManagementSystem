namespace WMS.Api.Application.Queries.Warehouses
{
    public class LocationViewModel
    {
        public string LocationId { get; set; }

        public LocationViewModel(string locationId)
        {
            LocationId = locationId;
        }
    }
}
