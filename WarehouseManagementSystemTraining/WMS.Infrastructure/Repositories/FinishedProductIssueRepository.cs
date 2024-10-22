namespace WMS.Infrastructure.Repositories
{
    public class FinishedProductIssueRepository : BaseRepository, IFinishedProductIssueRepository
    {
        public FinishedProductIssueRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<FinishedProductIssue> AddAsync(FinishedProductIssue finishedProductIssue)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssue.FinishedProductIssueId);
            if (existingItem != null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssue.FinishedProductIssueId} already exists.");
            }

            await _context.finishedProductIssues.AddAsync(finishedProductIssue);
            await _context.SaveChangesAsync();
            return finishedProductIssue;


        }

        public async Task<IEnumerable<FinishedProductIssue>> GetIssueById(string finishedProductIssueId)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssueId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssueId} does not exist.");
            }

            var finishedProductIssuelist = await _context.finishedProductIssues
                .Where(x => x.FinishedProductIssueId == finishedProductIssueId)
                .ToListAsync();

            return finishedProductIssuelist;
        }

        public async Task<FinishedProductIssue> Update(string finishedProductIssueId, FinishedProductIssue finishedProductIssue)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssueId);

            if (existingItem == null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssueId} does not exist.");
            }

            // Update the item
            existingItem.UpdateFinishedProductIssue(finishedProductIssue.Receiver, finishedProductIssue.Timestamp, finishedProductIssue.Employee, finishedProductIssue.Entries);

            await _context.SaveChangesAsync();

            return existingItem;
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

    }
}
