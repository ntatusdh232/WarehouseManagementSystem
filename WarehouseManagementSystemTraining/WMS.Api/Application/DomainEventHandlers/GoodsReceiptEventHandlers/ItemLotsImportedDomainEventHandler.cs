


namespace WMS.Api.Application.DomainEventHandlers.GoodsReceiptEventHandlers;

public class ItemLotsImportedDomainEventHandler : INotificationHandler<ItemLotsImportedDomainEvent>
{
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;

    public ItemLotsImportedDomainEventHandler(IGoodsReceiptRepository goodsReceiptRepository)
    {
        _goodsReceiptRepository = goodsReceiptRepository;
    }

    public Task Handle(ItemLotsImportedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
