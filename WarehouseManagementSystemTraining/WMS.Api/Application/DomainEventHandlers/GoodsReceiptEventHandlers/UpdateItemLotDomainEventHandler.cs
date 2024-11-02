
namespace WMS.Api.Application.DomainEventHandlers.GoodsReceiptEventHandlers;

public class UpdateItemLotDomainEventHandler : INotificationHandler<UpdateItemLotDomainEvent>
{
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;

    public UpdateItemLotDomainEventHandler(IGoodsReceiptRepository goodsReceiptRepository)
    {
        _goodsReceiptRepository = goodsReceiptRepository;
    }

    public Task Handle(UpdateItemLotDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
