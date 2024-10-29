namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptsByTimeQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
        public DateTime TimeTamp {  get; set; }
        public bool IsCompleted { get; set; }

        public GetGoodsReceiptsByTimeQuery(DateTime timeTamp, bool isCompleted)
        {
            TimeTamp = timeTamp;
            IsCompleted = isCompleted;
        }
    }
}
