namespace WMS.Api.Application.DomainEventHandlers.IsolatedItemLotEventHandlers
{
    public class BackToItemLotDomainEventHandler : INotificationHandler<BackToItemLotDomainEvent>
    {
        private readonly IItemLotRepository _itemLotRepository;
        private readonly IItemLotLocationRepository _itemLotLocationRepository;

        public BackToItemLotDomainEventHandler(IItemLotRepository itemLotRepository, IItemLotLocationRepository itemLotLocationRepository)
        {
            _itemLotRepository = itemLotRepository;
            _itemLotLocationRepository = itemLotLocationRepository;
        }

        public async Task Handle(BackToItemLotDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
