namespace WMS.Api.Application.Queries.Items
{
    public class GetAllItemsAsyncQueryHandler : IRequestHandler<GetAllItemsAsyncQuery, IEnumerable<ItemViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly ItemQueries itemQueries;

        public GetAllItemsAsyncQueryHandler(IMapper mapper, IItemRepository itemRepository, ItemQueries itemQueries)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            this.itemQueries = itemQueries;
        }

        public async Task<IEnumerable<ItemViewModel>> Handle(GetAllItemsAsyncQuery request, CancellationToken cancellationToken)
        {
            var items = new List<Item>();

            if (request.ItemClassId != null)
            {
                items = await itemQueries._items.Where(s => s.ItemClassId == request.ItemClassId).ToListAsync();
            }
            else
            {
                items = await itemQueries._items.ToListAsync();
            }

            var itemViewModels = _mapper.Map<IEnumerable<ItemViewModel>>(items);

            return itemViewModels;

        }


    }
}
