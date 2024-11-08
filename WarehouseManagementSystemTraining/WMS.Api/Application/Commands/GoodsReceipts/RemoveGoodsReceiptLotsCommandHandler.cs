namespace WMS.Api.Application.Commands.GoodsReceipts
{
    public class RemoveGoodsReceiptLotsCommandHandler : IRequestHandler<RemoveGoodsReceiptLotsCommand,bool>
    {
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly IGoodsIssueRepository  _goodsIssueRepository;

        public RemoveGoodsReceiptLotsCommandHandler(IGoodsReceiptRepository goodsReceiptRepository, IGoodsIssueRepository goodsIssueRepository)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
            _goodsIssueRepository = goodsIssueRepository;
        }

        public async Task<bool> Handle(RemoveGoodsReceiptLotsCommand request, CancellationToken cancellationToken)
        {
            var goodsReceipt = await _goodsReceiptRepository.GetGoodsReceiptById(request.GoodsReceiptId)
                ?? throw new EntityNotFoundException(nameof(GoodsReceipt), request.GoodsReceiptId);

            var removeGoodsReceiptLots = new List<GoodsReceiptLot>();

            foreach (var lot in request.GoodsReceiptLotIds)
            {
                var goodsReceiptLot = await _goodsReceiptRepository.GetGoodsReceiptLotById(request.GoodsReceiptId,lot)
                    ?? throw new EntityNotFoundException(nameof(GoodsReceiptLot), lot);

                var exportedGoodsIssueLot = await _goodsIssueRepository.GetGoodsIssueLotById(lot);

                if (exportedGoodsIssueLot != null)
                {
                    throw new ExportedItemLotException(lot);
                }

                removeGoodsReceiptLots.Add(goodsReceiptLot);

                goodsReceipt.RemoveLot(goodsReceiptLot);

            }
            
            goodsReceipt.RemoveItemLotEntities(removeGoodsReceiptLots);

            await _goodsReceiptRepository.Update(goodsReceipt);

            return await _goodsReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }
    }

}
