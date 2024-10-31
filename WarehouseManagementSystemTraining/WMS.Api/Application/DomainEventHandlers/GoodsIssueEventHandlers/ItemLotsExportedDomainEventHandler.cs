namespace WMS.Api.Application.DomainEventHandlers.GoodsIssueEventHandlers
{
    public class ItemLotsExportedDomainEventHandler : INotificationHandler<ItemLotsExportedDomainEvent>
    {
        private readonly IItemLotRepository _itemLotRepository;

        public ItemLotsExportedDomainEventHandler(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }

        public Task Handle(ItemLotsExportedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
