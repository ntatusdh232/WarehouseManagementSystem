namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
    }
}
