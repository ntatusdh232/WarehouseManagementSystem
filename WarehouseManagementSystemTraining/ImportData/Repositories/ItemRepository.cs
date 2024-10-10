using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.Repositories
{
    public class ItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Item GetItemById(string itemId)
        {
            return _context.items.AsNoTracking().FirstOrDefault(i => i.ItemId == itemId);
        }

        public void AddItem(Item item)
        {
            _context.items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            _context.items.Update(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
