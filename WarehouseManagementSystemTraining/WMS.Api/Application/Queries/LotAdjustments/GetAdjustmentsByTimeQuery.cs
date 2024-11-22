namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetAdjustmentsByTimeQuery : PaginatedQuery, IRequest<IEnumerable<LotAdjustmentViewModel>>
    {
        public TimeRangeQuery Query;

        public GetAdjustmentsByTimeQuery(TimeRangeQuery query)
        {
            Query = query;
        }
    }
}


