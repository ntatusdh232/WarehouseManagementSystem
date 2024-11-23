namespace WMS.Infrastructure.Repositories
{
    public class ItemClassRepository : BaseRepository, IItemClassRepository
    {
        public ItemClassRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ItemClass?> GetById(string itemClassId)
        {
            var existingItemClass = await _context.itemsClass.FindAsync(itemClassId);
            return existingItemClass;
        }
    }
}
