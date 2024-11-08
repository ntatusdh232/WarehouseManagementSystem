
namespace WMS.Api.Application.Commands.GoodsReceipts;

public class UpdateGoodsReceiptCommandHandler : IRequestHandler<UpdateGoodsReceiptCommand, bool>
{
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;
    private readonly IItemLotRepository _itemLotRepository;
    private readonly IStorageRepository _storageRepository;

    public UpdateGoodsReceiptCommandHandler(IGoodsReceiptRepository goodsReceiptRepository, IItemLotRepository itemLotRepository, IStorageRepository storageRepository)
    {
        _goodsReceiptRepository = goodsReceiptRepository;
        _itemLotRepository = itemLotRepository;
        _storageRepository = storageRepository;
    }

    public async Task<bool> Handle(UpdateGoodsReceiptCommand request, CancellationToken cancellationToken)
    {
        var goodsReceipt = await _goodsReceiptRepository.GetGoodsReceiptById(request.GoodsReceiptId);
        if(goodsReceipt is null)
        {
            throw new EntityNotFoundException(nameof(GoodsReceipt), request.GoodsReceiptId);
        }
        foreach (var updatedGoodsReceiptLot in request.GoodsReceiptLots)
        {
            var oldGoodsReceiptLot = goodsReceipt.Lots.FirstOrDefault(lot => lot.GoodsReceiptLotId == updatedGoodsReceiptLot.OldGoodsReceiptLotId);
            if(oldGoodsReceiptLot is null)
            {
                throw new EntityNotFoundException(nameof(GoodsReceiptLot), updatedGoodsReceiptLot.OldGoodsReceiptLotId);
            }
            var itemLot = await _itemLotRepository.GetItemLotById(updatedGoodsReceiptLot.OldGoodsReceiptLotId);

            var changedQuantity = updatedGoodsReceiptLot.Quantity - oldGoodsReceiptLot.Quantity;

            var itemLotLocations = new List<ItemLotLocation>();

            var sublots = new List<GoodsReceiptSublot>();

            if(updatedGoodsReceiptLot.ItemLotLocations != null)
            {
                double totalLotQuantity = 0;

                foreach (var itemLotLocationVM  in updatedGoodsReceiptLot.ItemLotLocations)
                {
                    var location = await _storageRepository.GetLocationsById(itemLotLocationVM.LocationId);

                    if(location is null)
                    {
                        throw new EntityNotFoundException(nameof(Location), itemLotLocationVM.LocationId);
                    }
                    var sublot = new GoodsReceiptSublot(itemLotLocationVM.LocationId,itemLotLocationVM.QuantityPerLocation);

                    sublots.Add(sublot);

                    var itemLotLocation = new ItemLotLocation(itemLotLocationVM.LocationId, itemLotLocationVM.QuantityPerLocation);

                    itemLotLocations.Add(itemLotLocation);

                    totalLotQuantity += itemLotLocationVM.QuantityPerLocation;
                   
                }
                if (totalLotQuantity != updatedGoodsReceiptLot.Quantity)
                {
                    throw new InvalidItemLotException("Total quantity per location does not match the updated quantity.");
                }
            }
            goodsReceipt.UpdateLot(oldLotId: updatedGoodsReceiptLot.OldGoodsReceiptLotId,
                                newLotId: updatedGoodsReceiptLot.NewGoodsReceiptLotId,
                                quantity: updatedGoodsReceiptLot.Quantity,
                                sublots: sublots,
                                productionDate: updatedGoodsReceiptLot.ProductionDate,
                                expirationDate: updatedGoodsReceiptLot.ExpirationDate,
                                note: updatedGoodsReceiptLot.Note);
            goodsReceipt.UpdateItemLotEntity(oldLotId: updatedGoodsReceiptLot.OldGoodsReceiptLotId,
                                             newLotId: updatedGoodsReceiptLot.NewGoodsReceiptLotId,
                                             itemLotLocations: itemLotLocations,
                                             quantity: updatedGoodsReceiptLot.Quantity,
                                             productionDate: updatedGoodsReceiptLot.ProductionDate,
                                             expirationDate: updatedGoodsReceiptLot.ExpirationDate);
        }
        await _goodsReceiptRepository.Update(goodsReceipt);

        return await _goodsReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
