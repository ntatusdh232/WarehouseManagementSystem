namespace WMS.Infrastructure.Repositories
{
    internal class ItemClassRepository : BaseRepository, IItemClassRepository
    {
        public ItemClassRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ItemClass?> GetById(string itemClassId)
        {
            var existingItemClass = await _context.itemsClass.FindAsync(itemClassId);
            if (existingItemClass is null)
            {
                throw new ArgumentException($"ItemClass does not exists.");
            }
            return existingItemClass;
        }
    }
}
