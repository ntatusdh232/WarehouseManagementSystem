
namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetAdjustmentsByTimeQueryHandler : IRequestHandler<GetAdjustmentsByTimeQuery, IEnumerable<LotAdjustmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly LotAdjustmentQueries lotAdjustmentQueries;

        public GetAdjustmentsByTimeQueryHandler(IMapper mapper, LotAdjustmentQueries lotAdjustmentQueries)
        {
            _mapper = mapper;
            this.lotAdjustmentQueries = lotAdjustmentQueries;
        }

        public async Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetAdjustmentsByTimeQuery query, CancellationToken cancellationToken)
        {
            var adjustments = await lotAdjustmentQueries._lotAdjustments
                .Where(s => s.Timestamp >= query.StartTime && s.Timestamp <= query.EndTime)
                .Where(s => s.IsConfirmed)
                .ToListAsync();

            var adjustmentViewModels = _mapper.Map<IEnumerable<LotAdjustmentViewModel>>(adjustments);

            return adjustmentViewModels;

        }
    }

}

