using Microsoft.EntityFrameworkCore;

namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductIssueRepository : BaseRepository, IFinishedProductIssueRepository
    {
        public FinishedProductIssueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FinishedProductIssue finishedProductIssue)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssue.FinishedProductIssueId);
            await _context.finishedProductIssues.AddAsync(finishedProductIssue);
        }

        public async Task<FinishedProductIssue> GetIssueById(string finishedProductIssueId)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssueId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssueId} does not exist.");
            }

            return existingItem;
        }


        public async Task<FinishedProductIssue> Update(FinishedProductIssue finishedProductIssue)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssue.FinishedProductIssueId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssue.FinishedProductIssueId} does not exist.");
            }

            existingItem.UpdateFinishedProductIssue(finishedProductIssue.Receiver, finishedProductIssue.Timestamp, finishedProductIssue.Employee, finishedProductIssue.Entries);

            await _context.SaveChangesAsync();

            return existingItem;
        }

        public async Task<IEnumerable<string>> GetReceivers()
        {
            var receivers = await _context.finishedProductIssues
                .AsNoTracking()
                .Select(s => s.Receiver)
                .ToArrayAsync()
                ?? throw new ArgumentException("No receivers found.");

            return receivers;
        }
        public async Task UpdateEntries(FinishedProductIssue finishedProductIssue)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssue.FinishedProductIssueId);

            existingItem.UpdateEntry(finishedProductIssue.Entries);

        }

        public async Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry()
        {
            var finishedProductIssueEntryList = await _context.finishedProductIssues
                .SelectMany(s => s.Entries) 
                .ToListAsync();


            if (finishedProductIssueEntryList == null || !finishedProductIssueEntryList.Any())
            {
                throw new ArgumentException("No entries found.");
            }

            return finishedProductIssueEntryList;
        }

        public async Task<List<FinishedProductIssueEntry>> GetAllByFinishedProductIssueIdAsync(string finishedProductIssueId, CancellationToken cancellationToken)
        {
            return await _context.finishedProductIssuesEntry
                .Where(s => s.FinishedProductIssueId == finishedProductIssueId)
                .ToListAsync(cancellationToken);
        }

        public async Task RemoveRangeAsync(IEnumerable<FinishedProductIssueEntry> finishedProductIssueEntries, CancellationToken cancellationToken)
        {
            _context.finishedProductIssuesEntry.RemoveRange(finishedProductIssueEntries);
            await _context.SaveChangesAsync(cancellationToken);
        }



    }
}
