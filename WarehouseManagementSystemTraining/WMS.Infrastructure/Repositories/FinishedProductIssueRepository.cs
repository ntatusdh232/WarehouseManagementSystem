using WMS.Domain.AggregateModels.FinishedProductAggregate;

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


        public Task<FinishedProductIssue> Update(string finishedProductIssueId, FinishedProductIssue finishedProductIssue)
        {

           throw new NotImplementedException();
        }

        public Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry()
        {

           throw new NotImplementedException();
        }




    }
}
