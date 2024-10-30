namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class FilterQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
        public IEnumerable<GoodsReceiptViewModel> goodsReceipts { get; set; }
        public IQueryable<GoodsReceiptLot> goodsReceiptLots { get; set; }

        public FilterQuery(IEnumerable<GoodsReceiptViewModel> goodsReceipts, IQueryable<GoodsReceiptLot> goodsReceiptLots)
        {
            this.goodsReceipts = goodsReceipts;
            this.goodsReceiptLots = goodsReceiptLots;
        }
    }
}
