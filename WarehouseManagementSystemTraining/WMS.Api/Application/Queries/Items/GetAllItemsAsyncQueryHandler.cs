namespace WMS.Api.Application.Queries.Items
{
    public class GetAllItemsAsyncQueryHandler : IRequestHandler<GetAllItemsAsyncQuery, IEnumerable<ItemViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetAllItemsAsyncQueryHandler(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemViewModel>> Handle(GetAllItemsAsyncQuery request, CancellationToken cancellationToken)
        {
            var ItemList = await _itemRepository.GetItemsByItemClass(request.ItemClassId);
            var ItemViewModel = _mapper.Map<IEnumerable<ItemViewModel>>(ItemList);
            return ItemViewModel;

        }


    }
}
