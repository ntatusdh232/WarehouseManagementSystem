namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetAllGoodsIssueIdsQueryHandler : IRequestHandler<GetAllGoodsIssueIdsQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetAllGoodsIssueIdsQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
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

        public async Task<IEnumerable<string>> Handle(GetAllGoodsIssueIdsQuery request, CancellationToken cancellationToken)
        {
            var goodsIssueIds = new List<string> { };

            if (request.IsExported == true)
            {
                goodsIssueIds = await _goodsIssues
                    .Where(gi => gi.Entries.Count > 0 && gi.Entries
                    .All(gie => gie.Lots.Count != 0) && gi.Entries
                    .All(gie => gie.RequestedQuantity <= gie.Lots
                    .Sum(lot => lot.Quantity)))
                    .Select(gi => gi.GoodsIssueId)
                    .ToListAsync();
            }

            if (request.IsExported == false)
            {
                goodsIssueIds = await _goodsIssues
                    .Where(gi => gi.Entries.Count == 0 || gi.Entries
                    .Any(gie => gie.Lots.Count == 0) || gi.Entries
                    .Any(gie => gie.RequestedQuantity > gie.Lots
                    .Sum(lot => lot.Quantity)))
                    .Select(gi => gi.GoodsIssueId)
                    .ToListAsync();
            }

            return goodsIssueIds;
        }
    }

}

