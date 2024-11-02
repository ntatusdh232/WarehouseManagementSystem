
namespace WMS.Api.Application.DomainEventHandlers.FinishedProductReceiptEventHandlers;

public class UpdateInventoryOnRemoveProductReceiptEntryDomainEventHandler : INotificationHandler<UpdateInventoryOnRemoveProductReceiptEntryDomainEvent>
{
    private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

    public UpdateInventoryOnRemoveProductReceiptEntryDomainEventHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository)
    {
        _finishedProductReceiptRepository = finishedProductReceiptRepository;
    }

    public Task Handle(UpdateInventoryOnRemoveProductReceiptEntryDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
