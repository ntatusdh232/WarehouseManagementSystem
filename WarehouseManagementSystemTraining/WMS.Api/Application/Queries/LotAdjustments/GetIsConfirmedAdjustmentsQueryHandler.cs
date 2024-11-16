
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetIsConfirmedAdjustmentsQueryHandler : IRequestHandler<GetIsConfirmedAdjustmentsQuery, IEnumerable<LotAdjustmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetIsConfirmedAdjustmentsQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IQueryable<LotAdjustment> _lotAdjustments => _context.lotAdjustments
            .AsNoTracking()
            .Include(a => a.Item)
            .Include(a => a.Employee)
            .Include(a => a.SublotAdjustments);


        public async Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetIsConfirmedAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var confirmedAdjustments = await _lotAdjustments
                .Where(s => s.IsConfirmed == request.IsConfirmed)
                .ToListAsync();

            var confirmedAdjustmentViewModels = _mapper.Map<IEnumerable<LotAdjustmentViewModel>>(confirmedAdjustments);

            return confirmedAdjustmentViewModels;
        }


    }
}


