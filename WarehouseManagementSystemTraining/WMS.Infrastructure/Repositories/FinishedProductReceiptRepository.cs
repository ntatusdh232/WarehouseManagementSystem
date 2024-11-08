namespace WMS.Infrastructure.Repositories
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

        public async Task<FinishedProductReceipt> GetReceiptById(string finishedProductReceiptId)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductReceiptId} does not exist.");
            }

            return existingItem;
        }

        public async Task<IEnumerable<string>> GetReceiptIds()
        {
            var ReceiptIdList = await _context.finishedProductReceipts.Select(s => s.FinishedProductReceiptId).ToListAsync();

            return ReceiptIdList;
        }

        public async Task<IEnumerable<FinishedProductReceipt>> GetReceiptByTime(DateTime query)
        {
            var receiptList = await _context.finishedProductReceipts.Where(s => s.Timestamp == query).ToListAsync();
            return receiptList;
        }

        public async Task<FinishedProductReceipt> Update(FinishedProductReceipt finishedProductReceipt)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceipt.FinishedProductReceiptId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductReceipt.FinishedProductReceiptId} does not exist.");
            }

            existingItem.UpdateFinishedProductReceipt(finishedProductReceipt.Timestamp, finishedProductReceipt.Employee, finishedProductReceipt.Entries);

            await _context.SaveChangesAsync();
            return existingItem;
        }

        public async Task Remove(string finishedProductReceiptId)
        {
            var existingItem = _context.finishedProductReceipts.Find(finishedProductReceiptId);
            if (existingItem == null)
            {
                throw new KeyNotFoundException();
            }
            _context.finishedProductReceipts.Remove(existingItem);

            

        }
    }
}
