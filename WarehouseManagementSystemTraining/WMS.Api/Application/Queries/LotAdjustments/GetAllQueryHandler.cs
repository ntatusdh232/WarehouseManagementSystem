
namespace WMS.Api.Application.Queries.LotAdjustments;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<LotAdjustmentViewModel>>
{
    public Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
