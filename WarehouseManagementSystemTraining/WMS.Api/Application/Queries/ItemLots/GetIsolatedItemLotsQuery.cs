namespace WMS.Api.Application.Queries.ItemLots;

public class GetIsolatedItemLotsQuery : PaginatedQuery, IRequest<IEnumerable<ItemLotViewModel>>
{
    public bool IsIsolated {  get; set; }

    public GetIsolatedItemLotsQuery(bool isIsolated)
    {
        IsIsolated = isIsolated;
    }
}
