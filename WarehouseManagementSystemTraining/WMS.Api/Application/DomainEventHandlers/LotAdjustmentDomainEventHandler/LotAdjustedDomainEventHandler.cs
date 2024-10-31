namespace WMS.Api.Application.DomainEventHandlers.LotAdjustmentDomainEventHandler
{
    public class LotAdjustedDomainEventHandler : INotificationHandler<LotAdjustedDomainEvent>
    {
        private readonly IItemLotRepository _itemLotRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IInventoryLogEntryRepository _inventoryLogEntryRepository;
        private readonly IStorageRepository _storageRepository;

        public LotAdjustedDomainEventHandler(IItemLotRepository itemLotRepository, IItemRepository itemRepository, IInventoryLogEntryRepository inventoryLogEntryRepository, IStorageRepository storageRepository)
        {
            _itemLotRepository = itemLotRepository;
            _itemRepository = itemRepository;
            _inventoryLogEntryRepository = inventoryLogEntryRepository;
            _storageRepository = storageRepository;
        }

        public async Task Handle(LotAdjustedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
