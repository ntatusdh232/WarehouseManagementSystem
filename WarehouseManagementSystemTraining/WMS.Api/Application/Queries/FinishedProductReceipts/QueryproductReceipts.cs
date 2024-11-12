namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class QueryproductReceipts
    {
        private readonly ApplicationDbContext _context;
        public QueryproductReceipts(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<FinishedProductReceipt> _productReceipts => _context.finishedProductReceipts
            .AsNoTracking().Include(gr => gr.Employee).Include(gr => gr.Entries).ThenInclude(gr => gr.Item);
    }
}
