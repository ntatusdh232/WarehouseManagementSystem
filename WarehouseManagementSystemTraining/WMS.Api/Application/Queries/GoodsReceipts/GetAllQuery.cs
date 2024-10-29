namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetAllQuery : PaginatedQuery, IRequest<IEnumerable<GoodsReceiptViewModel>>
    {
    }
}
