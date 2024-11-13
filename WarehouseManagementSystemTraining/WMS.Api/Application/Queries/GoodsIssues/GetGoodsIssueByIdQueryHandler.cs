namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetGoodsIssueByIdQueryHandler : IRequestHandler<GetGoodsIssueByIdQuery, QueryResult<GoodsIssueViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly GoodsIssueQueries goodsIssuesQuery;

        public GetGoodsIssueByIdQueryHandler(ApplicationDbContext context, IMapper mapper, GoodsIssueQueries Query)
        {
            _context = context;
            _mapper = mapper;
            goodsIssuesQuery = Query;
        }

        public async Task<QueryResult<GoodsIssueViewModel>> Handle(GetGoodsIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var goodsIssue = await goodsIssuesQuery._goodsIssues.FirstOrDefaultAsync(s => s.GoodsIssueId == request.GoodsIssueId);
            if (goodsIssue == null)
            {
                throw new EntityNotFoundException(nameof(GoodsIssue), request.GoodsIssueId);
            }
            var goodsIssueViewModel = _mapper.Map<QueryResult<GoodsIssueViewModel>>(goodsIssue);

            return goodsIssueViewModel;

        }


    }
}


