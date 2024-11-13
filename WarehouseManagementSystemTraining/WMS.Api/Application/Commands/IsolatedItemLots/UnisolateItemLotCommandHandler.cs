namespace WMS.Api.Application.Commands.IsolatedItemLots
{
    public class UnisolateItemLotCommandHandler : IRequestHandler<UnisolateItemLotCommand,bool>
    {
        private readonly IItemLotRepository _itemLotRepository;
        private readonly IIsolatedItemLotRepository _isolatedItemLotRepository;
        private readonly IStorageRepository _storageRepository;

        public UnisolateItemLotCommandHandler(IItemLotRepository itemLotRepository, IIsolatedItemLotRepository isolatedItemLotRepository, IStorageRepository storageRepository)
        {
            _itemLotRepository = itemLotRepository;
            _isolatedItemLotRepository = isolatedItemLotRepository;
            _storageRepository = storageRepository;
        }

        public double unisolatedQuantity { get; set; } = 0;

        public async Task<bool> Handle(UnisolateItemLotCommand request, CancellationToken cancellationToken)
        {
            var isolatedLot = await _isolatedItemLotRepository.GetItemLotById(request.ItemLotId)
                ?? throw new EntityNotFoundException(nameof(IsolatedItemLot), request.ItemLotId);


            var itemLot = await _itemLotRepository.GetItemLotById(request.ItemLotId)
                ?? throw new EntityNotFoundException(nameof(ItemLot), request.ItemLotId);


            var itemLotLocations = new List<ItemLotLocation>();

            foreach (var unisolatedSublot in request.UnisolatedItemSublots)
            {
                var location = await _storageRepository.GetLocationById(unisolatedSublot.LocationId)
                    ?? throw new EntityNotFoundException(nameof(Location), unisolatedSublot.LocationId);


                var itemLotLocation = new ItemLotLocation(itemLotId: itemLot.LotId,
                                                          locationId: location.LocationId,
                                                          quantityPerLocation: unisolatedSublot.QuantityPerLocation);

                itemLotLocations.Add(itemLotLocation);

                unisolatedQuantity += unisolatedSublot.QuantityPerLocation;
            }

            isolatedLot.UpdateQuantity(unisolatedQuantity);

            if (isolatedLot.Quantity == 0)
            {
                await _isolatedItemLotRepository.Remove(isolatedLot.ItemLotId);
                itemLot.Unisolated();
            }

            if (isolatedLot.Quantity > 0)
            {
                await _isolatedItemLotRepository.Update(isolatedLot);
            }

            isolatedLot.BackToItemLot(itemLot: itemLot,
                                      unisolatedItemLotLocations: itemLotLocations,
                                      unisolatedQuantity: unisolatedQuantity);

            return await _isolatedItemLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
