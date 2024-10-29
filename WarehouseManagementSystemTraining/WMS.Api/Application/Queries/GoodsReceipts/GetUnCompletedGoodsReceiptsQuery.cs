namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetUnCompletedGoodsReceiptsQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
    }
}
