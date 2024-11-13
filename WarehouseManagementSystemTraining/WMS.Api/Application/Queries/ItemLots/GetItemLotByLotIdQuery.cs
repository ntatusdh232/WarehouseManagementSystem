namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotByLotIdQuery : PaginatedQuery, IRequest<QueryResult<ItemLotViewModel>>
    {
        public string LotId { get; set; }

        public GetItemLotByLotIdQuery(string lotId)
        {
            LotId = lotId;
        }
    }
}


