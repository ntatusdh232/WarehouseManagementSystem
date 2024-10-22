namespace WMS.Infrastructure.Repositories
{
    internal class GoodsIssueRepository : BaseRepository, IGoodsIssueRepository
    {
        public GoodsIssueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<GoodsIssue> Add(GoodsIssue goodsIssue)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssue.GoodsIssueId);
            if (existingGoodsIssue == goodsIssue)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssue.GoodsIssueId} already exists.");
            }

            await _context.goodsIssues.AddAsync(goodsIssue);
            await _context.SaveChangesAsync();
            return goodsIssue;
        }

        public async Task<GoodsIssue?> GetGoodsIssueById(string goodsIssueId)
        {
            var goodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);
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

        public async Task Remove(string goodsIssueId)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);
            if(existingGoodsIssue is null)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssueId} does not exist.");
            }
            _context.goodsIssues.Remove(existingGoodsIssue);
            await _context.SaveChangesAsync();
        }

        public async Task Update(string goodsIssueId, GoodsIssue goodsIssue)
        {
            var existingGoodsIssue = await _context.goodsIssues.FindAsync(goodsIssueId);
            if (existingGoodsIssue is null)
            {
                throw new ArgumentException($"GoodsIssue with ID {goodsIssueId} does not exist.");
            }
            existingGoodsIssue.UpdateGoodsIssue(goodsIssue.Receiver, goodsIssue.Timestamp);
            await _context.SaveChangesAsync();
        }
    }
}
