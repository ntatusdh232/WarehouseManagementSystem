
namespace WMS.Api.Application.Queries.LotAdjustments;

public class GetAdjustmentsByTimeQueryHandler : IRequestHandler<GetAdjustmentsByTimeQuery, IEnumerable<LotAdjustmentViewModel>>
{
    public Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetAdjustmentsByTimeQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
