namespace WMS.Api.Application.Queries.Items
{
    public class GetItemByIdAsyncQueryHandler : IRequestHandler<GetItemByIdAsyncQuery, ItemViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private Item item { get; set; }

        public GetItemByIdAsyncQueryHandler(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }



        public async Task<ItemViewModel> Handle(GetItemByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            if (request.Unit is null)
            {
                item = await _itemRepository.GetItemById(request.ItemId);
            }
            else
            {
                item = await _itemRepository.GetItemByIdAndUnit(request.ItemId, request.Unit);
            }

            if (item == null)
            {
                throw new EntityNotFoundException(nameof(Item), request.ItemId);
            }
            var ItemViewModel = _mapper.Map<ItemViewModel>(item);
            return ItemViewModel;

        }
    }
}
