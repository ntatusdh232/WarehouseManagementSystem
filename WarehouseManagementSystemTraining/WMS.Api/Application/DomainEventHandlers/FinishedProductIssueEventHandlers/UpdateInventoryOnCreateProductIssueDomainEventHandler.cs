namespace WMS.Api.Application.DomainEventHandlers.FinishedProductIssueEventHandlers
{
    public class UpdateInventoryOnCreateProductIssueDomainEventHandler : INotificationHandler<UpdateInventoryOnCreateProductIssueDomainEvent>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public UpdateInventoryOnCreateProductIssueDomainEventHandler(IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task Handle(UpdateInventoryOnCreateProductIssueDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
