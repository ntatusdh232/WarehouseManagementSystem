namespace WMS.Api.Application.Queries.ItemLots
{
    public class ItemLotsQueries
    {
        private readonly ApplicationDbContext _context;

        public ItemLotsQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<ItemLot> _itemLots => _context.itemsLot
            .AsNoTracking()
            .Include(il => il.ItemLotLocations)
            .ThenInclude(ill => ill.Location)
            .Include(il => il.Item);
    }
}
