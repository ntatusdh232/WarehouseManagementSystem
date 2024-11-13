using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

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
                if (receipt != null)
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
                if (receipt != null)
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

        public async Task<GoodsReceipt> Add(GoodsReceipt goodsReceipt)
        {
            var exitingItem = await _context.goodsReceipts.FindAsync(goodsReceipt.GoodsReceiptId);

            if (exitingItem != null)
            {
                throw new ArgumentException($"GoodsReceipt with ID {goodsReceipt.GoodsReceiptId} already exists.");
            }

            await _context.goodsReceipts.AddAsync(goodsReceipt);
            await _context.SaveChangesAsync();
            return goodsReceipt;

        }

        public async Task<GoodsReceipt> Update(GoodsReceipt goodsReceipt)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceipt.GoodsReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"GoodsReceipt with ID {goodsReceipt.GoodsReceiptId} does not exist.");
            }

            existingItem.UpdateGoodsReceipt(goodsReceipt.GoodsReceiptId, goodsReceipt.Supplier, goodsReceipt.Timestamp,
                                       goodsReceipt.Employee, goodsReceipt.Lots);

            await _context.SaveChangesAsync();
            return existingItem;

        }

        public async Task Remove(string goodsReceiptId)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"GoodsReceipt with ID {goodsReceiptId} does not exist.");
            }

            _context.goodsReceipts.Remove(existingItem);
            await _context.SaveChangesAsync();

        }

        public async Task<GoodsReceipt> GetGoodsReceiptById(string goodsReceiptId)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"GoodsReceipt with ID {goodsReceiptId} does not exist.");
            }

            return existingItem;

        }

        public async Task<GoodsReceiptLot> GetGoodsReceiptLotById(string goodsReceiptId, string goodsReceiptLotId)
        {
            var existingGoodsReceipt = await _context.goodsReceipts.FindAsync(goodsReceiptId)
                ?? throw new ArgumentException($"GoodsReceipt with ID {goodsReceiptId} does not exist.");

            var lot = existingGoodsReceipt.Lots.FirstOrDefault(x => x.GoodsReceiptLotId == goodsReceiptLotId)
                ?? throw new ArgumentException($"GoodsReceiptLot with ID {goodsReceiptLotId} does not exist.");

            return lot;
        }

        public async Task<IEnumerable<GoodsReceipt>> GetGoodsReceiptByGoodsReceiptId(string goodsReceiptId)
        {
            var existingItem = await _context.goodsReceipts.FindAsync(goodsReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"GoodsReceipt with ID {goodsReceiptId} does not exist.");
            }
            var goodsReceipt = await _context.goodsReceipts
                .Where(x => x.GoodsReceiptId == goodsReceiptId)
                .ToListAsync();

            return goodsReceipt;

        }


    }
}
