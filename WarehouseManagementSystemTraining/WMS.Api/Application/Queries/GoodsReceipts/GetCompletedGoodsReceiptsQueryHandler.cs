﻿namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly ApplicationDbContext _context;

        public GetCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
            _context = context;
        }

        private IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .AsNoTracking().Include(gr => gr.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Item)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(gr => gr.Sublots);

        private IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var completedGoodsReceipts = await _goodsReceipts
                .Where(g => g.Lots.All(lot => lot.ProductionDate != null
                                           && lot.ExpirationDate != null
                                           && lot.Sublots.Count > 0)
                         && g.Supplier != null)
                .ToListAsync();

            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

            var newGoodsReceiptViewModel = await Filter(goodsReceipts: goodsReceiptViewModel,
                                                        goodsIssueLots: _goodsIssueLots);

            return newGoodsReceiptViewModel;

        }
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetCompleteGoodsReceipt()
        {
            var completedGoodsReceipts = await _goodsReceipts
                .Where(g => g.Lots.All(lot => lot.ProductionDate != null
                                           && lot.ExpirationDate != null
                                           && lot.Sublots.Count > 0)
                         && g.Supplier != null)
                .ToListAsync();

            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

            var newGoodsReceiptViewModel = await Filter(goodsReceipts: goodsReceiptViewModel,
                                                        goodsIssueLots: _goodsIssueLots);

            return newGoodsReceiptViewModel;
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
