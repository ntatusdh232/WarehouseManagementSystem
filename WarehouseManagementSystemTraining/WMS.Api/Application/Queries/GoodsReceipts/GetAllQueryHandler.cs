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
            var goodsReceipts = await _goodsReceipts.ToListAsync();

            //var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceipts);

            var goodsReceiptViewModels = goodsReceipts.Select(gr => new GoodsReceiptViewModel(
                gr.GoodsReceiptId,
                gr.Supplier,
                gr.Timestamp,
                _mapper.Map<EmployeeViewModel>(gr.Employee),
                gr.Lots.Select(lot => new GoodsReceiptLotViewModel(
                    lot.GoodsReceiptLotId,
                    lot.Quantity,
                    lot.ProductionDate ?? DateTime.MinValue,
                    lot.ExpirationDate ?? DateTime.MinValue,
                    lot.Note,
                    lot.IsExported,
                    _mapper.Map<EmployeeViewModel>(lot.Employee),
                    _mapper.Map<ItemViewModel>(lot.Item),
                    lot.Sublots.Select(sublot => new GoodsReceiptSublotViewModel(
                        sublot.LocationId,
                        sublot.QuantityPerLocation
                    )).ToList()
                )).ToList()
            ));



            return goodsReceiptViewModels;

        }

        private async Task<IEnumerable<GoodsReceiptViewModel>> Filter(IEnumerable<GoodsReceiptViewModel> goodsReceipts,IQueryable<GoodsReceiptLot> goodsReceiptLots)
        {
            if (goodsReceipts == null)
            {
                throw new ArgumentNullException(nameof(goodsReceipts), "GoodsReceipts cannot be null");
            }

            var goodsReceiptLotIds = goodsReceipts
                .Where(gr => gr.GoodsReceiptLots != null)
                .SelectMany(gr => gr.GoodsReceiptLots.Select(lot => lot.GoodsReceiptLotId))
                .ToList();

            var exportedGoodsIssueLots = await goodsReceiptLots
                .Where(il => goodsReceiptLotIds.Contains(il.GoodsReceiptLotId))
                .ToListAsync();

            foreach (var goodsReceipt in goodsReceipts)
            {
                if (goodsReceipt.GoodsReceiptLots == null) continue;

                foreach (var receiptLot in goodsReceipt.GoodsReceiptLots
                    .Where(receiptLot => exportedGoodsIssueLots.Exists(il => il.GoodsReceiptLotId == receiptLot.GoodsReceiptLotId)))
                {
                    receiptLot.IsExported = true;
                }
            }

            return goodsReceipts;
        }

    }
}
