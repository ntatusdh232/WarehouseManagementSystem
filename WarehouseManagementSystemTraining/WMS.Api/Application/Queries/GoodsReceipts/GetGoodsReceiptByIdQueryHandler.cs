namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptByIdQueryHandler : IRequestHandler<GetGoodsReceiptByIdQuery, QueryResult<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly GoodsReceiptQueries goodsReceiptQuery;
        private readonly ApplicationDbContext _context;

        public GetGoodsReceiptByIdQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, GoodsReceiptQueries goodsReceiptQuery, ApplicationDbContext context)
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

        public async Task<QueryResult<GoodsReceiptViewModel>> Handle(GetGoodsReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipt = await goodsReceiptQuery._goodsReceipts.FirstOrDefaultAsync(g => g.GoodsReceiptId == request.goodsReceiptId);
            var goodsReceiptViewModel = _mapper.Map<GoodsReceiptViewModel>(goodsReceipt);
            
            if (goodsReceiptViewModel is null)
            {
                return null;
            }

            foreach(var receiptLot in goodsReceiptViewModel.GoodsReceiptLots)
            {
                var itemLot = await _goodsIssueLots
                    .FirstOrDefaultAsync(l => l.GoodsIssueLotId == receiptLot.GoodsReceiptLotId);
                if (itemLot != null)
                {
                    receiptLot.UpdateIsExported();
                }
            }

            var newgoodsReceiptViewModel = _mapper.Map<QueryResult<GoodsReceiptViewModel>>(goodsReceiptViewModel);

            return newgoodsReceiptViewModel;

        }
    }
}
