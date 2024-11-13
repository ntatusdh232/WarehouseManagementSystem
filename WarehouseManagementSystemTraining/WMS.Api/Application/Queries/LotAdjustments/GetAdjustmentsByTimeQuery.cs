namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetAdjustmentsByTimeQuery : PaginatedQuery, IRequest<IEnumerable<LotAdjustmentViewModel>>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public GetAdjustmentsByTimeQuery(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}


