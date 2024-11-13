
namespace WMS.Api.Application.Commands.ItemLots;

public class IsolateItemLotCommandHandler : IRequestHandler<IsolateItemLotCommand, bool>
{
    private readonly IItemLotRepository _itemLotRepository;
    private readonly IStorageRepository _storageRepository;

    public IsolateItemLotCommandHandler(IItemLotRepository itemLotRepository, IStorageRepository storageRepository)
    {
        _itemLotRepository = itemLotRepository;
        _storageRepository = storageRepository;
    }

    public async Task<bool> Handle(IsolateItemLotCommand request, CancellationToken cancellationToken)
    {
        var itemLot = await _itemLotRepository.GetItemLotById(request.ItemLotId);
        if (itemLot is null)
        {
            throw new EntityNotFoundException(nameof(ItemLot), request.ItemLotId);
        }
        var isolatedQuantity = request.IsolatedItemSublots.Sum(s => s.Quantity);
        foreach (var sublot in request.IsolatedItemSublots)
        {
            var location = await _storageRepository.GetLocationById(sublot.LocationId);
            if (location is null)
            {
                throw new EntityNotFoundException(nameof(Location), sublot.LocationId);
            }
            var isolatedSublot = itemLot.ItemLotLocations.Find(ill => ill.ItemLotId == itemLot.LotId && ill.LocationId == location.LocationId);
            if (isolatedSublot is null)
            {
                throw new EntityNotFoundException(nameof(ItemLotLocation), location.LocationId);
            }
            isolatedSublot.UpdateQuantity(-sublot.Quantity);
            if (isolatedSublot.QuantityPerLocation == 0)
            {
                itemLot.ItemLotLocations.Remove(isolatedSublot);
            }
        }
        itemLot.Isolate(isolatedQuantity);

        await _itemLotRepository.UpdateLot(itemLot);

        return await _itemLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
