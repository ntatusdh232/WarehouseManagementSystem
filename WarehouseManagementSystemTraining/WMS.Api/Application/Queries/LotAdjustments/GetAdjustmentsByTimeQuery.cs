namespace WMS.Api.Application.Queries.LotAdjustments;

public class GetAdjustmentsByTimeQuery : PaginatedQuery, IRequest<IEnumerable<LotAdjustmentViewModel>>
{
}
