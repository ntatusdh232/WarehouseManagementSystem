namespace WMS.Api.Application.Queries
{
    public class TimeRangeQuery : Query
    {
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 

        public TimeRangeQuery(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
