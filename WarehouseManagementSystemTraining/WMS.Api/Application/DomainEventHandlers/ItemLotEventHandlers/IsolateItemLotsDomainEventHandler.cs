

namespace WMS.Api.Application.DomainEventHandlers.ItemLotEventHandlers;

public class IsolateItemLotsDomainEventHandler : INotificationHandler<IsolateItemLotsDomainEvent>
{
    private readonly IIsolatedItemLotRepository _isolatedItemLotRepository;

    public IsolateItemLotsDomainEventHandler(IIsolatedItemLotRepository isolatedItemLotRepository)
    {
        _isolatedItemLotRepository = isolatedItemLotRepository;
    }

    public Task Handle(IsolateItemLotsDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
