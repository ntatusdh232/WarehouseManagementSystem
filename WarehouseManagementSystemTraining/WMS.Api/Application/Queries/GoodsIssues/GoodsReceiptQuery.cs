namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GoodsReceiptQuery

    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<GoodsIssue> _goodsIssues => _context.goodsIssues
        .Include(s => s.Employee)
        .Include(s => s.Entries)
            .ThenInclude(x => x.Item)
        .Include(s => s.Entries)
            .ThenInclude(x => x.Lots)
                .ThenInclude(gil => gil.Sublots)
        .Include(s => s.Entries)
            .ThenInclude(x => x.Lots)
                .ThenInclude(z => z.Employee)
        .AsNoTracking();
    }
}
