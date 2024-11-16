namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsIssueViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(ApplicationDbContext context, IMapper mapper)
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

        public async Task<IEnumerable<GoodsIssueViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsIssues = await _goodsIssues.ToListAsync();

            var goodsIssueViewModels = _mapper.Map<IEnumerable<GoodsIssueViewModel>>(goodsIssues);

            return goodsIssueViewModels;


        }
    }
}


