using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

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

        private IQueryable<GoodsReceiptLot> _goodsReceiptLots => _context.goodsReceiptsLot
            .Include(lot => lot.Sublots)
            .AsNoTracking();


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

            if (goodsReceipt == null)
            {
                return null;
            }

            var goodsReceiptViewModel = new GoodsReceiptViewModel(
                goodsReceipt.GoodsReceiptId,
                goodsReceipt.Supplier,
                goodsReceipt.Timestamp,
                _mapper.Map<EmployeeViewModel>(goodsReceipt.Employee),
                goodsReceipt.Lots.Select(lot => new GoodsReceiptLotViewModel(
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
            );


            if (goodsReceiptViewModel is null)
            {
                return null;
            }

            foreach(var receiptLot in goodsReceiptViewModel.GoodsReceiptLots)
            {
                var itemLot = await _goodsReceiptLots
                    .FirstOrDefaultAsync(l => l.GoodsReceiptLotId == receiptLot.GoodsReceiptLotId);
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
