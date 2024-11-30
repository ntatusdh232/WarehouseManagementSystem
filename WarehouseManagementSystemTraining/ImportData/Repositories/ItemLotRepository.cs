namespace ImportData.Repositories
{
    public class ItemLotRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemLotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ItemLot GetItemLotById(string id)
        {
            return _context.itemsLot.AsNoTracking().FirstOrDefault(i => i.LotId == id);
        }

        public void AddItemLot(ItemLot itemLot)
        {
            _context.itemsLot.Add(itemLot);
        }

        public void UpdateItemLot(ItemLot itemLot)
        {
            _context.itemsLot.Update(itemLot);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ItemLot GetItemLotByItem(string itemId)
        {
            return _context.itemsLot
                .FirstOrDefault(x => x.ItemId == itemId);
        }
    }
}

