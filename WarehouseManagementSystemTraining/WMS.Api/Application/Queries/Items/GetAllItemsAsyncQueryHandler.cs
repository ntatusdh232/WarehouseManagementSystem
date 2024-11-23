namespace WMS.Api.Application.Queries.Items
{
    public class GetAllItemsAsyncQueryHandler : IRequestHandler<GetAllItemsAsyncQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly ApplicationDbContext _context;

        public GetAllItemsAsyncQueryHandler(IMapper mapper, IItemRepository itemRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _context = context;
        }

        private IQueryable<Item> _items => _context.items.AsNoTracking();

        public async Task<IEnumerable<string>> Handle(GetAllItemsAsyncQuery request, CancellationToken cancellationToken)
        {
            var items = new List<Item>();

            if (request.ItemClassId != null)
            {
                items = await _items.Where(s => s.ItemClassId == request.ItemClassId).ToListAsync();
            }
            else
            {
                items = await _items.ToListAsync();
            }

            var itemIds = items.Select(s => s.ItemId).ToList();

            return itemIds;

        }


    }
}
