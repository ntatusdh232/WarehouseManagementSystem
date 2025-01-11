using DocumentFormat.OpenXml.VariantTypes;

namespace WMS.Infrastructure.Repositories
{
    public class GoodsReceiptRepository : BaseRepository, IGoodsReceiptRepository
    {
        public GoodsReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GoodsReceipt>> GetCompletedGoodsReceipts()
        {
            var goodsReceiptLotCompleted = await _context.goodsReceiptsLot.Where(s => s.IsExported == true).ToListAsync();
            var goodsReceipts = new List<GoodsReceipt>();
            foreach (var i in goodsReceiptLotCompleted)
            {
                var receipt = await _context.goodsReceipts.FirstOrDefaultAsync(s => s.GoodsReceiptId == i.GoodsReceiptId);
                if (receipt is not null)
                {
                    goodsReceipts.Add(receipt);
                }
            }

            return goodsReceipts;
        }
        public async Task<IEnumerable<GoodsReceipt>> GetUnCompletedGoodsReceipts()
        {
            var goodsReceiptLotCompleted = await _context.goodsReceiptsLot.Where(s => s.IsExported == false).ToListAsync();
            var goodsReceipts = new List<GoodsReceipt>();
            foreach (var i in goodsReceiptLotCompleted)
            {
                var receipt = await _context.goodsReceipts.FirstOrDefaultAsync(s => s.GoodsReceiptId == i.GoodsReceiptId);
                if (receipt is not null)
                {
                    goodsReceipts.Add(receipt);
                }
            }

            return goodsReceipts;
        }

        public async Task<IEnumerable<GoodsReceipt>> GetAllGoodsReceipts()
        {
            var goodsReceipts = await _context.goodsReceipts.ToListAsync();

            return goodsReceipts;
        }

        public async Task<IList<string>> GetSuppliers()
        {
            var suppliers = await _context.goodsReceipts.AsNoTracking().Select(g => g.Supplier).Distinct().ToListAsync();

            return suppliers;
        }

        public async Task<IEnumerable<GoodsReceipt>> GetGoodsReceiptsByTime(DateTime timeTamp, bool isCompleted)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GoodsReceipt>> Filter(IEnumerable<GoodsReceipt> goodsReceipts, IQueryable<GoodsReceiptLot> goodsReceiptLots)
        {
            throw new NotImplementedException();
        }

        public async Task Add(GoodsReceipt goodsReceipt)
        {

            await _context.goodsReceipts.AddAsync(goodsReceipt);

        }

        public async Task Update(GoodsReceipt goodsReceipt)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceipt.GoodsReceiptId);

            existingItem.UpdateGoodsReceipt(goodsReceipt.Supplier, goodsReceipt.Timestamp,
                                       goodsReceipt.Employee, goodsReceipt.Lots);

        }

        public async Task Remove(string goodsReceiptId)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            _context.goodsReceipts.Remove(existingItem);

        }

        public async Task<GoodsReceipt> GetGoodsReceiptById(string goodsReceiptId)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            return existingItem;

        }

        public async Task<GoodsReceiptLot> GetGoodsReceiptLotById(string goodsReceiptId, string goodsReceiptLotId)
        {
            var goodsReceiptLot = await _context.goodsReceiptsLot.FirstOrDefaultAsync(s => s.GoodsReceiptId == goodsReceiptId && s.GoodsReceiptLotId == goodsReceiptLotId);
            
            return goodsReceiptLot;
        }

        public async Task<GoodsReceipt> GetGoodsReceiptByGoodsReceiptId(string goodsReceiptId)
        {
            var goodsReceipt = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            return goodsReceipt;

        }


    }
}
