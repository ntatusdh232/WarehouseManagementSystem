namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsIssueViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly GoodsIssueQueries goodsIssuesQuery;

        public GetAllQueryHandler(ApplicationDbContext context, IMapper mapper, GoodsIssueQueries goodsIssuesQuery)
        {
            _context = context;
            _mapper = mapper;
            this.goodsIssuesQuery = goodsIssuesQuery;
        }

        public async Task<IEnumerable<GoodsIssueViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsIssues = await goodsIssuesQuery._goodsIssues.ToListAsync();

            var goodsIssueViewModels = _mapper.Map<IEnumerable<GoodsIssueViewModel>>(goodsIssues);

            return goodsIssueViewModels;


        }
    }
}


