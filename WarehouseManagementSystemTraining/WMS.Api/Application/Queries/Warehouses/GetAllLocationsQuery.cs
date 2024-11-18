namespace WMS.Api.Application.Queries.Warehouses;

public class GetAllLocationsQuery : PaginatedQuery, IRequest<IEnumerable<LocationViewModel>>
{
}
