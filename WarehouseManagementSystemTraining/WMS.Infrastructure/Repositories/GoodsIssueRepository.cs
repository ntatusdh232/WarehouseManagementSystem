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
            if (existingGoodsIssue == goodsIssue)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssue.GoodsIssueId} already exists.");
            }

            await _context.goodsIssues.AddAsync(goodsIssue);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<GoodsIssue?> GetGoodsIssueById(string goodsIssueId)
        {
            var goodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);

            if (goodsIssue == null )
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssueId} does not exist.");
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
            if(existingGoodsIssue is null)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssueId} does not exist.");
            }
            _context.goodsIssues.Remove(existingGoodsIssue);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(GoodsIssue goodsIssue)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssue.GoodsIssueId);
            if (existingGoodsIssue is null)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssue.GoodsIssueId} does not exist.");
            }

            existingGoodsIssue.Update(goodsIssue);
        }


        public async Task<GoodsIssueEntry> GetEntryByGoodsIssueIdAndItemId(string goodsIssueId, string itemId)
        {
            var Entry = await _context.goodsIssuesEntry.FirstOrDefaultAsync(s => s.GoodsIssueId == goodsIssueId && s.ItemId == itemId);

            if (Entry is null)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssueId} does not exist.");
            }

            return Entry;
        }

        public async Task RemoveEntry(GoodsIssueEntry entry, CancellationToken cancellationToken)
        {
            var Entries = await _context.goodsIssuesEntry.FindAsync(entry.GoodsIssueEntryId);

            if (Entries is null)
            {
                throw new ArgumentException($"GoodsIssue does not exist.");
            }

            _context.goodsIssuesEntry.Remove(Entries);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task UpdateEntries(List<GoodsIssueEntry> goodsIssueEntries, CancellationToken cancellationToken)
        {
            if (goodsIssueEntries == null || !goodsIssueEntries.Any())
            {
                throw new ArgumentException("GoodsIssueEntry list is empty or null.");
            }

            _context.goodsIssuesEntry.UpdateRange(goodsIssueEntries);

            await _context.SaveChangesAsync(cancellationToken);
        }



    }
}
