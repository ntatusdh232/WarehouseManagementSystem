namespace WMS.Api.Application.Commands.Warehouses
{
    public class CreateLocationCommand : IRequest<bool>
    {
        public string WarehouseId { get; set; }
        public string LocationId { get; set; }

        public CreateLocationCommand(string warehouseId, string locationId)
        {
            WarehouseId = warehouseId;
            LocationId = locationId;
        }
    }
}
