using System.Linq;
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

        private IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        private IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .Include(gr => gr.Employee)
            .Include(gr => gr.Lots)
                .ThenInclude(grl => grl.Item)
            .Include(gr => gr.Lots)
                .ThenInclude(grl => grl.Employee)
            .Include(gr => gr.Lots)
                .ThenInclude(grl => grl.Sublots)
            .AsNoTracking();


        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipts = await _goodsReceipts.ToListAsync(cancellationToken);

            //var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceipts);

            var goodsReceiptViewModels = goodsReceipts.Select(gr => new GoodsReceiptViewModel(
                gr.GoodsReceiptId,
                gr.Supplier,
                gr.Timestamp,
                _mapper.Map<EmployeeViewModel>(gr.Employee),
                gr.Lots.Select(lot => new GoodsReceiptLotViewModel(
                    goodsReceiptLotId: lot.GoodsReceiptLotId,
                    quantity: lot.Quantity,
                    productionDate: lot.ProductionDate ?? DateTime.MinValue,
                    expirationDate: lot.ExpirationDate ?? DateTime.MinValue,
                    note: lot.Note,
                    isExported: lot.IsExported,
                    employee: _mapper.Map<EmployeeViewModel>(lot.Employee),
                    item: _mapper.Map<ItemViewModel>(lot.Item),
                    goodsReceiptSublots: lot.Sublots.Select(sublot => new GoodsReceiptSublotViewModel(
                        sublot.LocationId,
                        sublot.QuantityPerLocation
                    )).ToList()
                )).ToList()
            ));

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
