using MediatR;

namespace WMS.Infrastructure.Repositories
{
    public class GoodsIssueRepository : BaseRepository, IGoodsIssueRepository, IGoodsIssueEntryRepository
    {
        public GoodsIssueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Add(GoodsIssue goodsIssue, CancellationToken cancellationToken)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssue.GoodsIssueId);

            await _context.goodsIssues.AddAsync(goodsIssue);

            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<GoodsIssue?> GetGoodsIssueById(string goodsIssueId)
        {
            var goodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);

            var entries = await _context.goodsIssuesEntry.Where(s => s.GoodsIssueId == goodsIssueId).ToListAsync();

            var items = await _context.items.ToListAsync();

            foreach (var entry in entries)
            {
                var item = items.FirstOrDefault(s => s.ItemId == entry.ItemId);
                if (item != null)
                {
                    entry.Item = item;
                }
            }

            if (goodsIssue != null)
            {
                goodsIssue.Entries = entries;
            }

            return goodsIssue;
        }

        public async Task<GoodsIssueLot?> GetGoodsIssueLotById(string goodsIssueLotId)
        {
            var goodsIssueLot = await _context.goodsIssuesLot.FindAsync(goodsIssueLotId);
            return goodsIssueLot;
        }

        public async Task<IEnumerable<GoodsIssue>> GetListAsync()
        {
            var goodsIssuelist = await _context.goodsIssues.ToListAsync();
            return goodsIssuelist;
        }

        public async Task Remove(string goodsIssueId, CancellationToken cancellationToken)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);

            _context.goodsIssues.Remove(existingGoodsIssue);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(GoodsIssue goodsIssue)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssue.GoodsIssueId);

            existingGoodsIssue.Update(goodsIssue);
        }


        public async Task<GoodsIssueEntry> GetEntryByGoodsIssueIdAndItemId(string goodsIssueId, string itemId)
        {
            var Entry = await _context.goodsIssuesEntry.FirstOrDefaultAsync(s => s.GoodsIssueId == goodsIssueId && s.ItemId == itemId);

            return Entry;
        }

        public async Task RemoveEntry(GoodsIssueEntry entry, CancellationToken cancellationToken)
        {
            var Entries = await _context.goodsIssuesEntry.FindAsync(entry.GoodsIssueEntryId);

            _context.goodsIssuesEntry.Remove(Entries);

            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task UpdateEntries(List<GoodsIssueEntry> goodsIssueEntries, CancellationToken cancellationToken)
        {

            _context.goodsIssuesEntry.UpdateRange(goodsIssueEntries);

            await _context.SaveChangesAsync(cancellationToken);
        }



    }
}
