namespace WMS.Api.Application.DomainEventHandlers.FinishedProductIssueEventHandlers
{
    public class UpdateInventoryOnRemoveProductIssueEntryDomainEventHandler : INotificationHandler<UpdateInventoryOnRemoveProductIssueEntryDomainEvent>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public UpdateInventoryOnRemoveProductIssueEntryDomainEventHandler(IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task Handle(UpdateInventoryOnRemoveProductIssueEntryDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
