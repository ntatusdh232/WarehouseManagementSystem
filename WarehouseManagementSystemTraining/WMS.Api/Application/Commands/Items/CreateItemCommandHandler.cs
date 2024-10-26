using WMS.Domain.AggregateModels.ItemAggregate;

namespace WMS.Api.Application.Commands.Items
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand,bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemClassRepository _itemClassRepository;


        public CreateItemCommandHandler(IItemRepository itemRepository, IItemClassRepository itemClassRepository)
        {
            _itemRepository = itemRepository;
            _itemClassRepository = itemClassRepository;
        }

        public async Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            var Itemcheck = await _itemRepository.GetItemById(request.ItemId);
            if (Itemcheck != null)
            {
                throw new ArgumentException($"Item with ID {Itemcheck.ItemId} already exists.");
            }

            var item = new Item
            {
                ItemId =  request.ItemId,
                ItemName = request.ItemName,
                Unit = request.Unit,
                MinimumStockLevel = request.MinimumStockLevel,
                Price = request.Price,
                PacketSize = request.PacketSize,
                PacketUnit = request.PacketUnit,
                ItemClassId = request.ItemClassId

            };

            await _itemRepository.Add(item, cancellationToken);

            return true;

        }

    }
}
