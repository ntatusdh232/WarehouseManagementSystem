namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetByTimeQuery : PaginatedQuery, IRequest<IEnumerable<FinishedProductReceiptViewModel>>
    {
        public TimeRangeQuery Query {  get; set; }

        public GetByTimeQuery(TimeRangeQuery query)
        {
            Query = query;
        }
    }

}
