namespace WMS.Api.Application.Queries.GoodsIssues;

public class GoodsIssueQueries

{
    private readonly ApplicationDbContext _context;

    public GoodsIssueQueries(ApplicationDbContext context)
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


    public IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
    .AsNoTracking()
    .SelectMany(gi => gi.Entries)
    .SelectMany(e => e.Lots);
}
