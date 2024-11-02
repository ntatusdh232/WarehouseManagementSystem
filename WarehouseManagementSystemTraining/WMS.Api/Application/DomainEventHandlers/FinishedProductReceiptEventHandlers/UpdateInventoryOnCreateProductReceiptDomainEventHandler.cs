

namespace WMS.Api.Application.DomainEventHandlers.FinishedProductReceiptEventHandlers;

public class UpdateInventoryOnCreateProductReceiptDomainEventHandler : INotificationHandler<UpdateInventoryOnCreateProductReceiptDomainEvent>
{
    private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

    public UpdateInventoryOnCreateProductReceiptDomainEventHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository)
    {
        _finishedProductReceiptRepository = finishedProductReceiptRepository;
    }

    public Task Handle(UpdateInventoryOnCreateProductReceiptDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
