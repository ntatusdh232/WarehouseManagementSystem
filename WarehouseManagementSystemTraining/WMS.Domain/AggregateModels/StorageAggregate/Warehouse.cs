namespace WMS.Domain.AggregateModels.StorageAggregate
{
    public class Warehouse : IAggregateRoot
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public List<Location> Locations { get; set; }


#pragma warning disable CS8618
        private Warehouse() { }

        public Warehouse(string warehouseId, string warehouseName)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
        }

        public void AddLocation(Location location)
        {
            if (Locations == null)
            {
                Locations = new List<Location>();
            }
            Locations.Add(location);
        }

#pragma warning restore CS8618

    }
}
