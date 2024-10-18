namespace WMS.Domain.AggregateModels.WarehouseAggregate
{
    public class Warehouse : IAggregateRoot
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<Location> Locations { get; set; }
    }
}
