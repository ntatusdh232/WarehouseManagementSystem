namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetUnCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetUnCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUnCompletedGoodsReceiptsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        private IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .AsNoTracking().Include(gr => gr.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Item)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(gr => gr.Sublots);

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetUnCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var uncompletedGoodsReceipts = await _goodsReceipts
                                        .Where(g => g.Lots
                                        .All(lot => lot.ProductionDate == null && lot.ExpirationDate == null && lot.Sublots.Count == 0) && g.Supplier == null)
                                        .ToListAsync();

            var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(uncompletedGoodsReceipts);

            return await Filter(goodsReceiptViewModels, _goodsIssueLots);
        }

        private async Task<IEnumerable<GoodsReceiptViewModel>> Filter(IEnumerable<GoodsReceiptViewModel> goodsReceipts, IQueryable<GoodsIssueLot> goodsIssueLots)
        {
            if (goodsReceipts == null)
            {
                throw new ArgumentNullException(nameof(goodsReceipts), "GoodsReceipts cannot be null");
            }

            var goodsReceiptLotIds = goodsReceipts
                .Where(gr => gr.GoodsReceiptLots != null)
                .SelectMany(gr => gr.GoodsReceiptLots.Select(lot => lot.GoodsReceiptLotId))
                .ToList();

            var exportedGoodsIssueLots = await goodsIssueLots
                .Where(il => goodsReceiptLotIds.Contains(il.GoodsIssueLotId))
                .ToListAsync();

            foreach (var goodsReceipt in goodsReceipts)
            {
                if (goodsReceipt.GoodsReceiptLots == null) continue;

                foreach (var receiptLot in goodsReceipt.GoodsReceiptLots
                    .Where(receiptLot => exportedGoodsIssueLots.Exists(il => il.GoodsIssueLotId == receiptLot.GoodsReceiptLotId)))
                {
                    receiptLot.IsExported = true;
                }
            }

            return goodsReceipts;
        }

    }


}

