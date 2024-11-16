namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptByIdQueryHandler : IRequestHandler<GetGoodsReceiptByIdQuery, GoodsReceiptViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly ApplicationDbContext _context;

        public GetGoodsReceiptByIdQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
            _context = context;
        }

        private IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        public IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .AsNoTracking().Include(gr => gr.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Item)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(gr => gr.Sublots);

        public async Task<GoodsReceiptViewModel> Handle(GetGoodsReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipt = await _goodsReceipts.FirstOrDefaultAsync(g => g.GoodsReceiptId == request.goodsReceiptId);
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

            var newGoodsReceiptViewModel = _mapper.Map<GoodsReceiptViewModel>(goodsReceiptViewModel);

            return newGoodsReceiptViewModel;

        }
    }
}
