namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductIssueRepository : IRepository<FinishedProductIssue>, IRepository<FinishedProductIssueEntry>
    {
        Task AddAsync(FinishedProductIssue finishedProductIssue, CancellationToken cancellationToken);
        Task<FinishedProductIssue> GetIssueById(string finishedProductIssueId);
        Task<FinishedProductIssue> Update(FinishedProductIssue finishedProductIssue);
        Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry();
        Task UpdateEntries(FinishedProductIssue finishedProductIssue, CancellationToken cancellationToken);





    }

    public interface IFinsihedProductIssueEntryRepository : IRepository<FinishedProductIssueEntry>
    {
        Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry();
        Task<List<FinishedProductIssueEntry>> GetAllByFinishedProductIssueIdAsync(string finishedProductIssueId, CancellationToken cancellationToken);
        Task RemoveRangeAsync(IEnumerable<FinishedProductIssueEntry> finishedProductIssueEntries, CancellationToken cancellationToken);
    }
}