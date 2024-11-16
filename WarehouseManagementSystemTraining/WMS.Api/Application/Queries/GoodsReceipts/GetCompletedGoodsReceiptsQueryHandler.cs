namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly GoodsReceiptQueries goodsReceiptQuery;
        private readonly ApplicationDbContext _context;

        public GetCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, GoodsReceiptQueries goodsReceiptQuery, ApplicationDbContext context)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
            this.goodsReceiptQuery = goodsReceiptQuery;
            _context = context;
        }

        private IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);
        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var completedGoodsReceipts = await goodsReceiptQuery._goodsReceipts
                .Where(g => g.Lots.All(lot => lot.ProductionDate != null
                                           && lot.ExpirationDate != null
                                           && lot.Sublots.Count > 0)
                         && g.Supplier != null)
                .ToListAsync();

            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

            var newGoodsReceiptViewModel = await goodsReceiptQuery.Filter(goodsReceipts: goodsReceiptViewModel,
                                                                          goodsIssueLots: _goodsIssueLots);

            return newGoodsReceiptViewModel;

        }



    }
}
