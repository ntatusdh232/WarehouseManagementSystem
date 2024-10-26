namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class AddFinishedProductIssueEntriesCommandHandler : IRequestHandler<AddFinishedProductIssueEntriesCommand, bool>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public AddFinishedProductIssueEntriesCommandHandler(IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<bool> Handle(AddFinishedProductIssueEntriesCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue == null) return false;

            var issueEntries = request.Entries.Select(entry => 
            new FinishedProductIssueEntry
            {
                FinishedProductIssueEntryId = entry.FinishedProductIssueEntryId, PurchaseOrderNumber = entry.PurchaseOrderNumber, Quantity = entry.Quantity,
                Note = entry.Note, Item = entry.Item, ItemId = entry.ItemId, FinishedProductIssueId = entry.FinishedProductIssueId
            }
            ).ToList();

            foreach (var entry in issueEntries)
            {
                finishedProductIssue.Entries.Add(entry);
            }

            await _finishedProductIssueRepository.UpdateEntries(finishedProductIssue, cancellationToken);

            return true;
        }




    }
}
