namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetReceiptByIdQuery : PaginatedQuery, IRequest<QueryResult<FinishedProductReceiptViewModel>>
    {
        public string Id { get; set; }

        public GetReceiptByIdQuery(string id)
        {
            Id = id;
        }
    }
}
