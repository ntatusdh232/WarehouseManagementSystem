namespace WMS.Api.Application.Queries.Warehouses
{
    public class WarehouseViewModel
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<LocationViewModel> Locations { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public WarehouseViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public WarehouseViewModel(string warehouseId, string warehouseName, List<LocationViewModel> location)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Locations = location;
        }
    }   
}
