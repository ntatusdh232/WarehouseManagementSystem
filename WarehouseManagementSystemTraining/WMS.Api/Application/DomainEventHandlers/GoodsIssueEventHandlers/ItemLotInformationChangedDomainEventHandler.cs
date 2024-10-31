namespace WMS.Api.Application.DomainEventHandlers.GoodsIssueEventHandlers
{
    public class ItemLotInformationChangedDomainEventHandler : INotificationHandler<ItemLotInformationChangedDomainEvent>
    {
        private readonly IItemLotRepository _itemLotRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly IItemLotLocationRepository _itemLotLocationRepository;

        public ItemLotInformationChangedDomainEventHandler(IItemLotRepository itemLotRepository, IStorageRepository storageRepository, IItemLotLocationRepository itemLotLocationRepository)
        {
            _itemLotRepository = itemLotRepository;
            _storageRepository = storageRepository;
            _itemLotLocationRepository = itemLotLocationRepository;
        }

        public async Task Handle(ItemLotInformationChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
