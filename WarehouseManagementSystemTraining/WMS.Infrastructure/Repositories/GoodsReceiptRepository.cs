﻿using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

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
            var suppliers = await _context.goodsReceipts.Select(s => s.Supplier).ToListAsync();

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

        public async Task<IEnumerable<GoodsReceipt>> GetGoodsReceiptById(string goodsReceiptId)
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

        public async Task<IEnumerable<GoodsReceiptLot>> GetGoodsReceiptLotById(string goodsReceiptLotId)
        {
            var goodsReceipt = await _context.goodsReceipts
                .Include(s => s.Lots)
                .FirstOrDefaultAsync(s => s.Lots.Any(s => s.GoodsReceiptLotId == goodsReceiptLotId));

            if (goodsReceipt == null)
            {
                throw new ArgumentException($"No GoodsReceipt found with GoodsReceiptLotId = {goodsReceiptLotId}.");
            }

            var Lotslist = goodsReceipt.Lots
                .Where(lot => lot.GoodsReceiptLotId == goodsReceiptLotId);

            return Lotslist;

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
