namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class RemoveFinishedProductIssueEntryCommandHandler : IRequestHandler<RemoveFinishedProductIssueEntryCommand, bool>
    {
        private readonly IFinsihedProductIssueEntryRepository _finishedProductIssueEntryRepository;

        public RemoveFinishedProductIssueEntryCommandHandler(IFinsihedProductIssueEntryRepository finishedProductIssueEntryRepository)
        {
            _finishedProductIssueEntryRepository = finishedProductIssueEntryRepository;
        }

        public async Task<bool> Handle(RemoveFinishedProductIssueEntryCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssueEntries = await _finishedProductIssueEntryRepository
                .GetAllByFinishedProductIssueIdAsync(request.FinishedProductIssueId, cancellationToken);

            if (finishedProductIssueEntries == null || !finishedProductIssueEntries.Any())
            {
                return false; 
            }

            await _finishedProductIssueEntryRepository.RemoveRangeAsync(finishedProductIssueEntries, cancellationToken);

            return true;
        }

    }
}
