using WMS.Domain.AggregateModels.ItemAggregate;

namespace WMS.Api.Application.Commands.Items;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemClassRepository _itemClassRepository;

    public UpdateItemCommandHandler(IItemRepository itemRepository, IItemClassRepository itemClassRepository)
    {
        _itemRepository = itemRepository;
        _itemClassRepository = itemClassRepository;
    }

    public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetItemByIdAndUnit(request.ItemClassId, request.Unit);
        if (item is null)
        {
            throw new EntityNotFoundException(nameof(Item), request.ItemId);
        }
        var itemClass = await _itemClassRepository.GetById(request.ItemClassId);
        if (itemClass is null)
        {
            throw new EntityNotFoundException(nameof(ItemClass), request.ItemClassId);
        }
        item.Update(itemName: request.ItemName,
                    unit: request.Unit,
                    minimumStockLevel: request.MinimumStockLevel,
                    price: request.Price,
                    itemClassId: request.ItemClassId,
                    packetSize: request.PacketSize,
                    packetUnit: request.PacketUnit);

        await _itemRepository.Update(item);

        return await _itemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
