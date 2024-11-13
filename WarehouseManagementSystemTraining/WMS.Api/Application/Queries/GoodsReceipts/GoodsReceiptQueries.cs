namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GoodsReceiptQueries

    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<GoodsReceipt> _goodsReceipts => _context.goodsReceipts
            .AsNoTracking().Include(gr => gr.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Item)
            .Include(gr => gr.Lots)
            .ThenInclude(grl => grl.Employee)
            .Include(gr => gr.Lots)
            .ThenInclude(gr => gr.Sublots);

        public async Task<IEnumerable<GoodsReceiptViewModel>> Filter(IEnumerable<GoodsReceiptViewModel> goodsReceipts,
                                                                     IQueryable<GoodsIssueLot> goodsIssueLots)
        {
            var goodsReceiptLotIds = goodsReceipts.SelectMany(gr => gr.GoodsReceiptLots.Select(lot => lot.GoodsReceiptLotId))
                .ToList();
            var exportedGoodsIssueLots = await goodsIssueLots
                .Where(il => goodsReceiptLotIds.Contains(il.GoodsIssueLotId))
                .ToListAsync();

            foreach (var goodsReceipt in goodsReceipts)
            {
                foreach (var receiptLot in goodsReceipt.GoodsReceiptLots.Where(receiptLot => exportedGoodsIssueLots.Exists(il => il.GoodsIssueLotId == receiptLot.GoodsReceiptLotId)))
                {
                    receiptLot.IsExported = true;
                }
            }
            return goodsReceipts;
        }

    }
}
