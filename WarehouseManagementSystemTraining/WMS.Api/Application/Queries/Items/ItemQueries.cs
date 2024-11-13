namespace WMS.Api.Application.Queries.Items
{
    public class ItemQueries
    {
        private readonly ApplicationDbContext _context;

        public IQueryable<Item> _items => _context.items.AsNoTracking();


    }
}
