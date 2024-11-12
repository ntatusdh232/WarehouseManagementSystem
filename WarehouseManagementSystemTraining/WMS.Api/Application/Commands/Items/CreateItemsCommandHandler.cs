using WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository;
using WMS.Domain.AggregateModels.ItemAggregate;
using MediatR;

namespace WMS.Api.Application.Commands.Items
{
    public class CreateItemsCommandHandler : IRequestHandler<CreateItemsCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemClassRepository _itemClassRepository;

        public CreateItemsCommandHandler(IItemRepository itemRepository, IItemClassRepository itemClassRepository)
        {
            _itemRepository = itemRepository;
            _itemClassRepository = itemClassRepository;
        }

        

        public async Task<bool> Handle(CreateItemsCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Items)
            {
                var existedItem = await _itemRepository.GetItemByIdAndUnit(item.ItemId, item.Unit);

                if (existedItem != null) continue;

                var newItem = new Item(itemId: item.ItemId,
                                       itemName: item.ItemName,
                                       unit: item.Unit,
                                       minimumStockLevel: item.MinimumStockLevel,
                                       price: item.Price,
                                       packetSize: item.PacketSize,
                                       packetUnit: item.PacketUnit,
                                       itemClassId: item.ItemClassId
                                       );


                await _itemRepository.Add(newItem);
            }

            return await _itemClassRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


        }

    }
}
