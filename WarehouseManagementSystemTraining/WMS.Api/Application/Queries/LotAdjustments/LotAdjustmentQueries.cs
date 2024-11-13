using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class LotAdjustmentQueries
    {
        private readonly ApplicationDbContext _context;

        public LotAdjustmentQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<LotAdjustment> _lotAdjustments => _context.lotAdjustments
            .AsNoTracking()
            .Include(a => a.Item)
            .Include(a => a.Employee)
            .Include(a => a.SublotAdjustments);
    }
}
