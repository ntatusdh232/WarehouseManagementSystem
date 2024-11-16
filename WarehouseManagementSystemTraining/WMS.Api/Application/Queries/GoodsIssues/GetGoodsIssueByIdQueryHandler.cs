namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetGoodsIssueByIdQueryHandler : IRequestHandler<GetGoodsIssueByIdQuery, GoodsIssueViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGoodsIssueByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
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

        public async Task<GoodsIssueViewModel> Handle(GetGoodsIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssues.FirstOrDefaultAsync(s => s.GoodsIssueId == request.GoodsIssueId);
            
            if (goodsIssue == null)
            {
                throw new EntityNotFoundException(nameof(GoodsIssue), request.GoodsIssueId);
            }
            var goodsIssueViewModel = _mapper.Map<GoodsIssueViewModel>(goodsIssue);

            return goodsIssueViewModel;

        }


    }
}


