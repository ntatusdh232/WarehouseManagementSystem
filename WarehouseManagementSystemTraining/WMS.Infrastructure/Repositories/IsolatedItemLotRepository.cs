using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;

namespace WMS.Infrastructure.Repositories
{
    public class IsolatedItemLotRepository : BaseRepository, IIsolatedItemLotRepository
    {
        public IsolatedItemLotRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IsolatedItemLot> GetItemLotById(string lotId)
        {
            var existingItemLot = await _context.isolatedItemLots.FindAsync(lotId);

            if (existingItemLot == null)
            {
                throw new Exception("Not Found");
            }

            return existingItemLot;
           

        }   
        public async Task<IsolatedItemLot> AddAsync(IsolatedItemLot itemLot)
        {
            throw new NotSupportedException();

        }

        public async Task Update(IsolatedItemLot itemLot)
        {
            var updateItem = await _context.isolatedItemLots.FindAsync(itemLot.ItemLotId);
            if (updateItem is null)
            {
                throw new Exception("Not found");
            }

            _context.isolatedItemLots.Update(updateItem);

        }

        public async Task Remove(string lotId)
        {
            var removeItem = await _context.isolatedItemLots.FindAsync(lotId);
            if (removeItem is null)
            {
                throw new Exception("Not Found");
            }
            _context.isolatedItemLots.Remove(removeItem);

        }

        public async Task<IEnumerable<IsolatedItemLot>> GetAsync()
        {
            throw new NotImplementedException();

        }


    }
}
