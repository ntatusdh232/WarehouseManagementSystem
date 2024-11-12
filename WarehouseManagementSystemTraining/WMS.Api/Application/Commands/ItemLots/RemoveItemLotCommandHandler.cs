namespace WMS.Api.Application.Commands.ItemLots
{
    public class RemoveItemLotCommandHandler : IRequestHandler<RemoveItemLotCommand, bool>
    {
        private readonly IItemLotRepository _itemLotRepository;

        public RemoveItemLotCommandHandler(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }

        public async Task<bool> Handle(RemoveItemLotCommand request, CancellationToken cancellationToken)
        {
            var itemLot = await _itemLotRepository.GetItemLotById(request.ItemLotId)
                ?? throw new EntityNotFoundException(nameof(ItemLot), request.ItemLotId);

            if (itemLot.IsIsolated == false)
            {
                throw new EntityNotFoundException(nameof(ItemLot), request.ItemLotId);
            }

            await _itemLotRepository.Remove(itemLot.LotId);

            return await _itemLotRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
