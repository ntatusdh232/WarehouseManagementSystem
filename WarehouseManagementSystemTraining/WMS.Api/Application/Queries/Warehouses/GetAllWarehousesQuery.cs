namespace WMS.Api.Application.Queries.Warehouses
{
    public class GetAllWarehousesQuery : PaginatedQuery, IRequest<IEnumerable<WarehouseViewModel>>
    {
    }
}
