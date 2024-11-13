namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotsQuery : PaginatedQuery, IRequest<IEnumerable<ItemLotViewModel>>
    {
        public string itemId { get; set; }

        public GetItemLotsQuery(string itemId)
        {
            this.itemId = itemId;
        }
    }

}


