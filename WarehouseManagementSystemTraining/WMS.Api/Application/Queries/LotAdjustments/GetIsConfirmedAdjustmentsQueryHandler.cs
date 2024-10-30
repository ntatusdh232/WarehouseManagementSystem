
namespace WMS.Api.Application.Queries.LotAdjustments;

public class GetIsConfirmedAdjustmentsQueryHandler : IRequestHandler<GetIsConfirmedAdjustmentsQuery, IEnumerable<LotAdjustmentViewModel>>
{
    public Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetIsConfirmedAdjustmentsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
