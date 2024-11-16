using WMS.Domain.DomainEvents.InventoryLogEntryEvents;

namespace WMS.Api.Application.DomainEventHandlers.InventoryLogEntryEventHandlers
{
    public class InventoryLogEntryAddedDomainEventHandler : INotificationHandler<InventoryLogEntryAddedDomainEvent>
    {
        private readonly IInventoryLogEntryRepository _inventoryLogEntryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStorageRepository _storageRepository;

        public InventoryLogEntryAddedDomainEventHandler(IInventoryLogEntryRepository inventoryLogEntryRepository, IItemRepository itemRepository, IStorageRepository storageRepository)
        {
            _inventoryLogEntryRepository = inventoryLogEntryRepository;
            _itemRepository = itemRepository;
            _storageRepository = storageRepository;
        }

        public async Task Handle(InventoryLogEntryAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
