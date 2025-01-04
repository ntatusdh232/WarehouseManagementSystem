namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductReceiptRepository : BaseRepository, IFinishedProductReceiptRepository
    {
        public FinishedProductReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Add(FinishedProductReceipt finishedProductReceipt)
        {
            await _context.finishedProductReceipts.AddAsync(finishedProductReceipt);
        }

        public async Task<FinishedProductReceipt> GetReceiptById(string finishedProductReceiptId)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceiptId);

            var entries = await _context.finishedProductReceiptsEntry.Where(s => s.FinishedProductReceiptId == finishedProductReceiptId).ToListAsync();

            existingItem.AddEntries(entries);

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

        public async Task Update(FinishedProductReceipt finishedProductReceipt)
        {
            var existingItem = await _context.finishedProductReceipts.FindAsync(finishedProductReceipt.FinishedProductReceiptId);

            existingItem.UpdateFinishedProductReceipt(finishedProductReceipt.Timestamp, finishedProductReceipt.Employee, finishedProductReceipt.Entries);

        }

        public async Task Remove(string finishedProductReceiptId)
        {
            var existingItem = _context.finishedProductReceipts.Find(finishedProductReceiptId);

            _context.finishedProductReceipts.Remove(existingItem);

        }
    }
}
