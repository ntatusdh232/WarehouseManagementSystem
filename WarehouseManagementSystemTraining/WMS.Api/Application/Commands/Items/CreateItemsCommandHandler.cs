using WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository;
using WMS.Domain.AggregateModels.ItemAggregate;

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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var existingItems = await _itemRepository.GetAllItems();
            var existingItemIds = new HashSet<string>(existingItems.Select(item => item.ItemId));

            foreach (var itemRequest in request.Items)
            {
                if (existingItemIds.Contains(itemRequest.ItemId))
                {
                    throw new ArgumentException($"Item with ID {itemRequest.ItemId} already exists.");
                }

                var newItem = new Item
                (
                    itemRequest.ItemId,
                    itemRequest.ItemName,
                    itemRequest.Unit,
                    itemRequest.MinimumStockLevel,
                    itemRequest.Price,
                    itemRequest.PacketSize,
                    itemRequest.PacketUnit,
                    itemRequest.ItemClassId
                );

                await _itemRepository.Add(newItem, cancellationToken);
            };

            return true;


        }

    }
}
