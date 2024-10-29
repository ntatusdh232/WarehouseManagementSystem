namespace WMS.Api.Application.Queries.Items
{
    public class GetItemByIdAsyncQueryHandler : IRequestHandler<GetItemByIdAsyncQuery, QueryResult<ItemViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemByIdAsyncQueryHandler(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<QueryResult<ItemViewModel>> Handle(GetItemByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var ItemList = await _itemRepository.GetItemById(request.ItemId);
            var ItemViewModel = _mapper.Map<QueryResult<ItemViewModel>>(ItemList);
            return ItemViewModel;

        }
    }
}
