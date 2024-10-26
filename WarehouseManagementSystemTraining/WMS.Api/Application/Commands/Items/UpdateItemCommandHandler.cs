using WMS.Domain.AggregateModels.ItemAggregate;

namespace WMS.Api.Application.Commands.Items
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var item = await _itemRepository.GetItemById(request.ItemId)
                ?? throw new ArgumentException("GoodsIssue not found.");

            if (item == null)
            {
                throw new Exception($"Item  not found");
            }

            var itemclass = new ItemClass
            (
                request.ItemClassId
            );

            var newItem = new Item
            (
                request.ItemId,
                request.ItemName,
                request.Unit,
                request.MinimumStockLevel,
                request.Price,
                request.PacketSize,
                request.PacketUnit,
                request.ItemClassId
            );



            await _itemRepository.Update(newItem, request.ItemClassId, cancellationToken);

            return true;

        }
    }

}
