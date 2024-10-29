namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetByTimeQuery : PaginatedQuery, IRequest<IEnumerable<FinishedProductReceiptViewModel>>
    {
        public DateTime TimeTamp {  get; set; }

        public GetByTimeQuery(DateTime timeTamp)
        {
            TimeTamp = timeTamp;
        }
    }

}
