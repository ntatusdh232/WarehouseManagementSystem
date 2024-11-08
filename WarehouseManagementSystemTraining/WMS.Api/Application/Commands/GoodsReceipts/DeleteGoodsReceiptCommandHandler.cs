
namespace WMS.Api.Application.Commands.GoodsReceipts
{
    public class DeleteGoodsReceiptCommandHandler : IRequestHandler<DeleteGoodsReceiptCommand, bool>
    {
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public DeleteGoodsReceiptCommandHandler(IGoodsReceiptRepository goodsReceiptRepository)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<bool> Handle(DeleteGoodsReceiptCommand request, CancellationToken cancellationToken)
        {
            var removedGoodsReceipt = await _goodsReceiptRepository.GetGoodsReceiptById(request.GoodsReceiptId);
            if(removedGoodsReceipt is null)
            {
                throw new EntityNotFoundException(nameof(GoodsReceipt), request.GoodsReceiptId);
            }
            removedGoodsReceipt.RemoveItemLotEntities();
            await _goodsReceiptRepository.Remove(request.GoodsReceiptId);
            return await _goodsReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
