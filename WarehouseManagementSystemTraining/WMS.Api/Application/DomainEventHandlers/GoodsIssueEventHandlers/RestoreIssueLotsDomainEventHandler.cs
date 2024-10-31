namespace WMS.Api.Application.DomainEventHandlers.GoodsIssueEventHandlers
{
    public class RestoreIssueLotsDomainEventHandler : INotificationHandler<RestoreIssueLotsDomainEvent>
    {
        private readonly IItemLotRepository _itemLotRepository;

        public RestoreIssueLotsDomainEventHandler(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }

        public Task Handle(RestoreIssueLotsDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
