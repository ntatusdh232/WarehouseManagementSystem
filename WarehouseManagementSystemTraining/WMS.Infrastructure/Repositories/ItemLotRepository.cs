namespace WMS.Infrastructure.Repositories
{
    internal class ItemLotRepository : BaseRepository, IItemLotRepository
    {
        public ItemLotRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ItemLot> AddLot(ItemLot itemLot)
        {
            var existingItemLot = await _context.itemsLot.FindAsync(itemLot.LotId);
            if (existingItemLot == itemLot)
            {
                throw new ArgumentException($"ItemLot already exists.");
            }
            await _context.itemsLot.AddAsync(itemLot);
            await _context.SaveChangesAsync();
            return itemLot;
        }

        public async Task<IEnumerable<ItemLot>> AddLots(IEnumerable<ItemLot> itemLots)
        {
            var existingIds = await _context.itemsLot
                                             .Where(lot => itemLots.Select(i => i.LotId).Contains(lot.LotId))
                                             .Select(lot => lot.LotId)
                                             .ToListAsync();

            if (existingIds.Any())
            {
                throw new ArgumentException($"ItemLots with IDs {string.Join(", ", existingIds)} already exist.");
            }
            await _context.itemsLot.AddRangeAsync(itemLots);

            await _context.SaveChangesAsync();

            return itemLots;
        }

        public async Task Remove(string lotId)
        {
            var existingLot = await _context.itemsLot.FindAsync(lotId);
            if (existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            _context.itemsLot.Remove(existingLot);
        }

        public async Task DeleteLots(string lotId)
        {
            var existingLots = await _context.itemsLot.Where(x => x.LotId == lotId).ToListAsync();
            if (existingLots is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            _context.itemsLot.RemoveRange(existingLots);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemLot>> GetIsolatedItemLots()
        {
            var isolatedItemLots = await _context.itemsLot.Where(lot => !_context.items.Any(items => items.ItemId == lot.ItemId)).ToListAsync();   
            if (isolatedItemLots is null)
            {
                throw new ArgumentException($"IsolatedItemLot does not exists.");
            }
            return isolatedItemLots;
        }

        public async Task<ItemLot> GetItemLotById(string lotId)
        {
            var existingLot = await _context.itemsLot.FindAsync(lotId); 
            if (existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            return existingLot;
        }

        public async Task<IEnumerable<ItemLot>> GetLotsByItemId(string itemId)
        {
            var existingLot = await _context.itemsLot.Where(x => x.ItemId == itemId).ToListAsync();
            if(existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            return existingLot;
        }

        public async Task<ItemLot> UpdateLot(ItemLot itemLot)
        {
            var existingLot = await _context.itemsLot.FindAsync(itemLot.LotId);
            if(existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            existingLot.Update(itemLot.Quantity, itemLot.Timestamp, itemLot.ProductionDate, itemLot.ExpirationDate);
            return existingLot;
        }


            public async Task<IEnumerable<ItemLot>> UpdateLots(IEnumerable<ItemLot> updatedItemLots)
            {

                var lotIds = updatedItemLots.Select(lot => lot.LotId).ToList();

                var existingLots = await _context.itemsLot
                                                  .Where(lot => lotIds.Contains(lot.LotId))
                                                  .ToListAsync();


                var notFoundIds = lotIds.Except(existingLots.Select(lot => lot.LotId)).ToList();

                if (notFoundIds.Any())
                {
                    throw new ArgumentException($"ItemLots with IDs {string.Join(", ", notFoundIds)} not found.");
                }

                foreach (var existingLot in existingLots)
                {
                    var updatedLot = updatedItemLots.Single(lot => lot.LotId == existingLot.LotId);
                    existingLot.Update(updatedLot.Quantity, updatedLot.Timestamp, updatedLot.ProductionDate, updatedLot.ExpirationDate);
                }

                await _context.SaveChangesAsync();

                return existingLots; 
            }
        }
    }

