
namespace WMS.Api.Application.DomainEventHandlers.GoodsReceiptEventHandlers;

public class RemoveItemLotsDomainEventHandler : INotificationHandler<RemoveItemLotsDomainEvent>
{
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;

    public RemoveItemLotsDomainEventHandler(IGoodsReceiptRepository goodsReceiptRepository)
    {
        _goodsReceiptRepository = goodsReceiptRepository;
    }

    public Task Handle(RemoveItemLotsDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
