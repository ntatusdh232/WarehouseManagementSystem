namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptsByTimeQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
        public TimeRangeQuery Query {  get; set; }
        public bool IsCompleted { get; set; }

        public GetGoodsReceiptsByTimeQuery(TimeRangeQuery query, bool isCompleted)
        {
            Query = query;
            IsCompleted = isCompleted;
        }
    }
}
