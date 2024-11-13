using WMS.Domain.AggregateModels.ItemAggregate;

namespace WMS.Api.Application.Commands.Items;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, bool>
{
    private readonly IItemRepository _itemRepository;

    public CreateItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var existedItem = await _itemRepository.GetItemById(request.ItemId);
        if (existedItem != null)
        {
            throw new DuplicatedRecordException(nameof(Item), request.ItemId);
        }
        var newItem = new Item(itemId: request.ItemId,
                               itemName: request.ItemName,
                               unit: request.Unit,
                               minimumStockLevel: request.MinimumStockLevel,
                               price: request.Price,
                               packetSize: request.PacketSize,
                               packetUnit: request.PacketUnit,
                               itemClassId: request.ItemClassId);

        await _itemRepository.Add(newItem);

        return await _itemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
