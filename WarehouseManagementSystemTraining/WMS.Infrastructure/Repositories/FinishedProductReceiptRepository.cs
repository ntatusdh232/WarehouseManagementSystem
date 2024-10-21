﻿namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductReceiptRepository : BaseRepository, IFinishedProductReceiptRepository
    {
        public FinishedProductReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<FinishedProductReceipt> Add(FinishedProductReceipt finishedProductReceipt)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceipt.FinishedProductReceiptId);
            if (existingItem != null)
            {
                throw new ArgumentException($"Item with ID {finishedProductReceipt.FinishedProductReceiptId} already exists.");
            }

            await _context.finishedProductReceipts.AddAsync(finishedProductReceipt);
            await _context.SaveChangesAsync();
            return finishedProductReceipt;
        }

        public async Task<IEnumerable<FinishedProductReceipt>> GetReceiptById(string finishedProductReceiptId)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductReceiptId} does not exist.");
            }

            var finishedProductReceiptlist = await _context.finishedProductReceipts
                .Where(x => x.FinishedProductReceiptId == finishedProductReceiptId)
                .ToListAsync();

            return finishedProductReceiptlist;
        }

        public async Task<FinishedProductReceipt> Update(string finishedProductReceiptId, FinishedProductReceipt finishedProductReceipt)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductReceiptId} does not exist.");
            }

            throw new NotImplementedException();
        }

        public Task Remove(string finishedProductReceiptId)
        {
            throw new NotImplementedException();
        }
    }
}
