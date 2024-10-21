using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.AggregateModels.InventoryLogEntryAggregate;
using WMS.Domain.AggregateModels.ItemAggregate;

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
            // Kiểm tra xem có ItemLot nào đã tồn tại không
            var existingIds = await _context.itemsLot
                                             .Where(lot => itemLots.Select(i => i.LotId).Contains(lot.LotId))
                                             .Select(lot => lot.LotId)
                                             .ToListAsync();

            if (existingIds.Any())
            {
                throw new ArgumentException($"ItemLots with IDs {string.Join(", ", existingIds)} already exist.");
            }

            // Thêm các đối tượng ItemLot mới vào DbSet
            await _context.itemsLot.AddRangeAsync(itemLots);

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            return itemLots; // Trả về danh sách ItemLot đã được thêm
        }

        public async Task DeleteLot(string lotId)
        {
            var existingLot = await _context.itemsLot.Where(x => x.LotId == lotId).FirstOrDefaultAsync();
            if (existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            _context.itemsLot.Remove(existingLot);
            await _context.SaveChangesAsync();
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

        public async Task<ItemLot> GetLotByLotId(string lotId)
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

        public async Task<ItemLot> UpdateLot(string lotId, ItemLot itemLot)
        {
            var existingLot = await _context.itemsLot.FindAsync(lotId);
            if(existingLot is null)
            {
                throw new ArgumentException($"ItemLot does not exists.");
            }
            existingLot.Update(itemLot.Quantity, itemLot.Timestamp, itemLot.ProductionDate, itemLot.ExpirationDate);
            return existingLot;
        }


            public async Task<IEnumerable<ItemLot>> UpdateLots(IEnumerable<ItemLot> updatedItemLots)
            {
                // Lấy danh sách các ID của ItemLot cần cập nhật
                var lotIds = updatedItemLots.Select(lot => lot.LotId).ToList();

                // Tìm tất cả các bản ghi ItemLot có lotId trong cơ sở dữ liệu
                var existingLots = await _context.itemsLot
                                                  .Where(lot => lotIds.Contains(lot.LotId))
                                                  .ToListAsync();

                // Tạo danh sách các bản ghi không tìm thấy
                var notFoundIds = lotIds.Except(existingLots.Select(lot => lot.LotId)).ToList();

                // Nếu có bất kỳ bản ghi nào không tìm thấy, ném ra ngoại lệ
                if (notFoundIds.Any())
                {
                    throw new ArgumentException($"ItemLots with IDs {string.Join(", ", notFoundIds)} not found.");
                }

                // Cập nhật các thuộc tính của các bản ghi
                foreach (var existingLot in existingLots)
                {
                    var updatedLot = updatedItemLots.Single(lot => lot.LotId == existingLot.LotId);
                    existingLot.Update(updatedLot.Quantity, updatedLot.Timestamp, updatedLot.ProductionDate, updatedLot.ExpirationDate);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                return existingLots; // Trả về danh sách ItemLot đã được cập nhật
            }
        }
    }

