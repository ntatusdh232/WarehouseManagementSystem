namespace WMS.Api.Application.Queries.Items
{
    public class GetItemByIdAsyncQuery : PaginatedQuery, IRequest<ItemViewModel>
    {
        public string ItemId { get; set; }
        public string Unit { get; set; }

        public GetItemByIdAsyncQuery(string itemId, string unit)
        {
            ItemId = itemId;
            Unit = unit;
        }
    }
}
