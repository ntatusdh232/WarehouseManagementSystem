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
            throw new NotImplementedException();
        }




    }
}
