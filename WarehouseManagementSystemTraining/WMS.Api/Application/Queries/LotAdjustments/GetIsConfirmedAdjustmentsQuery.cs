namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetIsConfirmedAdjustmentsQuery : PaginatedQuery, IRequest<IEnumerable<LotAdjustmentViewModel>>
    {
        public bool IsConfirmed { get; set; }

        public GetIsConfirmedAdjustmentsQuery(bool isConfirmed)
        {
            IsConfirmed = isConfirmed;
        }
    }
}


