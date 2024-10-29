namespace WMS.Api.Application.Queries.Warehouses
{
    public class WarehouseViewModel
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<LocationViewModel> Locations { get; set; }

        public WarehouseViewModel(string warehouseId, string warehouseName, List<LocationViewModel> location)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Locations = location;
        }
    }   
}
