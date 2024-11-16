namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptByIdQuery : PaginatedQuery, IRequest<GoodsReceiptViewModel>
    {
        public string goodsReceiptId { get; set; }

        public GetGoodsReceiptByIdQuery(string goodsReceiptId)
        {
            this.goodsReceiptId = goodsReceiptId;
        }
    }
}
