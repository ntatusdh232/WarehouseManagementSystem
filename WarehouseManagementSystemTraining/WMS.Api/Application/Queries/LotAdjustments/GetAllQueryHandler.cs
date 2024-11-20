
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Queries.LotAdjustments;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<LotAdjustmentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public GetAllQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    private IQueryable<LotAdjustment> _lotAdjustments => _context.lotAdjustments
    .AsNoTracking()
    .Include(a => a.Item)
    .Include(a => a.Employee)
    .Include(a => a.SublotAdjustments);

    public async Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var adjustments = await _lotAdjustments.ToListAsync();

        var viewModels = _mapper.Map<IEnumerable<LotAdjustmentViewModel>>(adjustments);

        return viewModels;
    }
}
