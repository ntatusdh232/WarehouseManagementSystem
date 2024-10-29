namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetReceiptIdsQuery : PaginatedQuery, IRequest<IEnumerable<string>>
    {
    }
}
