
namespace WMS.Api.Application.DomainEventHandlers.FinishedProductReceiptEventHandlers;

public class UpdateInventoryOnModifyProductReceiptEntryDomainEventHandler : INotificationHandler<UpdateInventoryOnModifyProductReceiptEntryDomainEvent>
{
    private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

    public UpdateInventoryOnModifyProductReceiptEntryDomainEventHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository)
    {
        _finishedProductReceiptRepository = finishedProductReceiptRepository;
    }

    public Task Handle(UpdateInventoryOnModifyProductReceiptEntryDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
