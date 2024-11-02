﻿using Microsoft.EntityFrameworkCore;

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
            if (existingItem != null)
            {
                throw new ArgumentException($"Item with ID {finishedProductIssue.FinishedProductIssueId} already exists.");
            }

            await _context.finishedProductIssues.AddAsync(finishedProductIssue);

        }

        public async Task<FinishedProductIssue> GetIssueById(string finishedProductIssueId)
        {
            var existingItem = await _context.finishedProductIssues
                .FirstOrDefaultAsync(x => x.FinishedProductIssueId == finishedProductIssueId);

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

        public async Task UpdateEntries(FinishedProductIssue finishedProductIssue, CancellationToken cancellationToken)
        {
            var existingItem = await _context.finishedProductIssues.FindAsync(finishedProductIssue.FinishedProductIssueId);

            if (existingItem == null)
            {
                throw new Exception("Not Found");
            }

            existingItem.UpdateEntry(finishedProductIssue.Entries);

            await _context.SaveChangesAsync(cancellationToken);

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
