namespace WMS.Api.Application.Queries.FinishedProductReceipts;

public class GetReceiptByIdQuery : PaginatedQuery, IRequest<FinishedProductReceiptViewModel>
{
    public string FinishedProductReceiptId { get; set; }

    public GetReceiptByIdQuery(string finishedProductReceiptId)
    {
        FinishedProductReceiptId = finishedProductReceiptId;
    }
}
