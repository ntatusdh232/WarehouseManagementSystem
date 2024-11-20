namespace WMS.Api.Application.Queries.ItemLots;

public class GetItemLotsByLocationQuery : PaginatedQuery, IRequest<IEnumerable<ItemLotViewModel>>
{
    public string LocationId {  get; set; }

    public GetItemLotsByLocationQuery(string locationId)
    {
        LocationId = locationId;
    }
}


