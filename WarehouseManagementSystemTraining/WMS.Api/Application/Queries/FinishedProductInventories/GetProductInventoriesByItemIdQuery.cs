namespace WMS.Api.Application.Queries.FinishedProductInventories;

public class GetProductInventoriesByItemIdQuery : PaginatedQuery, IRequest<IEnumerable<FinishedProductInventoryViewModel>>
{
    public string ItemId { get; set; }

#pragma warning disable CS8618
    private GetProductInventoriesByItemIdQuery() { }

    public GetProductInventoriesByItemIdQuery(string itemId)
    {
        ItemId = itemId;
    }

}
