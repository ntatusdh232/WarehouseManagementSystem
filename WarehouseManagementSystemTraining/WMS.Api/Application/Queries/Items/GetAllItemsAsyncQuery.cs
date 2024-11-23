namespace WMS.Api.Application.Queries.Items
{
    public class GetAllItemsAsyncQuery : PaginatedQuery, IRequest<IEnumerable<string>>
    {
        public string ItemClassId { get; set; }

        public GetAllItemsAsyncQuery(string itemClassId)
        {
            ItemClassId = itemClassId;
        }
    }
}
