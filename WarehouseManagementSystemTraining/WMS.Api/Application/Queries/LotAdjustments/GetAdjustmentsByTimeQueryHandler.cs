
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetAdjustmentsByTimeQueryHandler : IRequestHandler<GetAdjustmentsByTimeQuery, IEnumerable<LotAdjustmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetAdjustmentsByTimeQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<LotAdjustment> _lotAdjustments => _context.lotAdjustments
            .AsNoTracking()
            .Include(a => a.Item)
            .Include(a => a.Employee)
            .Include(a => a.SublotAdjustments);

        public async Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetAdjustmentsByTimeQuery request, CancellationToken cancellationToken)
        {
            var adjustments = await _lotAdjustments
                .Where(s => s.Timestamp >= request.Query.StartTime && s.Timestamp <= request.Query.EndTime)
                .Where(s => s.IsConfirmed)
                .ToListAsync();

            var adjustmentViewModels = _mapper.Map<IEnumerable<LotAdjustmentViewModel>>(adjustments);

            return adjustmentViewModels;

        }
    }

}

