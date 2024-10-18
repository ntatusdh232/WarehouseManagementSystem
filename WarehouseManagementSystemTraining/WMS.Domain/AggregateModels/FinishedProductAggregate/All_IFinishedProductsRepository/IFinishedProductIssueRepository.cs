namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductIssueRepository : IRepository<FinishedProductIssue>, IRepository<FinishedProductIssueEntry>
    {
        Task<FinishedProductIssue> AddAsync(FinishedProductIssue finishedProductIssue);
        Task<IEnumerable<FinishedProductIssue>> GetIssueById(string finishedProductIssueId);    
        Task<FinishedProductIssue> Update(string finishedProductIssueId, FinishedProductIssue finishedProductIssue);
        Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry();

    }
}