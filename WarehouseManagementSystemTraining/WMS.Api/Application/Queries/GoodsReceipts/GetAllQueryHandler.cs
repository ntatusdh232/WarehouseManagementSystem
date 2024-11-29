using WMS.Api.Application.Queries.GoodsIssues;
using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetAllQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .Include(gr => gr.Employee)
            .Include(s => s.Lots)
                .ThenInclude(gil => gil.Sublots)
            .Include(s => s.Lots)
                .ThenInclude(z => z.Employee)
            .Include(s => s.Lots)
                .ThenInclude(z => z.Item)
            .AsNoTracking();

        public IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipts = await _goodsReceipts.ToListAsync();

            var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceipts);

            return goodsReceiptViewModels;

        }

        private async Task<IEnumerable<GoodsReceiptViewModel>> Filter(IEnumerable<GoodsReceiptViewModel> goodsReceipts,IQueryable<GoodsIssueLot> goodsIssueLots)
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
