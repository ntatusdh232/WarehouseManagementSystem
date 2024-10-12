namespace WMS.Domain.AggregateModels.WarehouseAggregate
{
    public class Warehouse
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<Location> Locations { get; set; }
    }
}
