namespace WMS.Api.Application.Queries.Warehouses;
public class GetWarehouseByIdQuery : PaginatedQuery, IRequest<QueryResult<WarehouseViewModel>>
{
    public string WarehouseId { get; set; }
    public GetWarehouseByIdQuery(string warehouseId)
    {
        WarehouseId = warehouseId;
    }
}