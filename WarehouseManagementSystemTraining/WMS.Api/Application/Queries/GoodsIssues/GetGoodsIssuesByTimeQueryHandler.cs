namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetGoodsIssuesByTimeQueryHandler : IRequestHandler<GetGoodsIssuesByTimeQuery, IEnumerable<GoodsIssueViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGoodsIssuesByTimeQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<GoodsIssue> _goodsIssues => _context.goodsIssues
                .Include(s => s.Employee)
                .Include(s => s.Entries)
                    .ThenInclude(x => x.Item)
                .Include(s => s.Entries)
                    .ThenInclude(x => x.Lots)
                        .ThenInclude(gil => gil.Sublots)
                .Include(s => s.Entries)
                    .ThenInclude(x => x.Lots)
                        .ThenInclude(z => z.Employee)
                .AsNoTracking();

        public async Task<IEnumerable<GoodsIssueViewModel>> Handle(GetGoodsIssuesByTimeQuery request, CancellationToken cancellationToken)
        {
            List<GoodsIssue> goodsIssues = new List<GoodsIssue>();

            if (request.isExported)
            {
                goodsIssues = goodsIssues = await _goodsIssues
                    .Where(gi => gi.Entries.Count > 0 &&
                                 gi.Entries.All(gie => gie.Lots.Count != 0) &&
                                 gi.Entries.All(gie => gie.RequestedQuantity <= gie.Lots.Sum(lot => lot.Quantity)))
                    .Where(gi => gi.Timestamp >= request.Query.StartTime && gi.Timestamp <= request.Query.EndTime)
                    .ToListAsync();
            }
            else
            {
                goodsIssues = await _goodsIssues
                   .Where(gi => gi.Entries.Count == 0 ||
                                gi.Entries.Any(gie => gie.Lots.Count == 0) ||
                                gi.Entries.Any(gie => gie.RequestedQuantity > gie.Lots.Sum(lot => lot.Quantity)))
                   .Where(gi => gi.Timestamp >= request.Query.StartTime && gi.Timestamp <= request.Query.EndTime)
                   .ToListAsync();
            }

            return _mapper.Map<IEnumerable<GoodsIssueViewModel>>(goodsIssues);

        }
    }

}

