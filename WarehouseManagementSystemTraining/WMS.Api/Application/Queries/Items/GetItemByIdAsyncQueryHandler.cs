
namespace WMS.Api.Application.Queries.Items
{
    public class GetItemByIdAsyncQueryHandler : IRequestHandler<GetItemByIdAsyncQuery, ItemViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetItemByIdAsyncQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        private IQueryable<Item> _items => _context.items.AsNoTracking();
        private Item item;

        public async Task<ItemViewModel> Handle(GetItemByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            if (request.Unit != null)
            {
                item = await _items.Where(x => x.ItemId == request.ItemId && x.Unit == request.Unit).FirstOrDefaultAsync();

            }
            else
            {
                item = await _items.Where(x => x.ItemId == request.ItemId).FirstOrDefaultAsync();
            }

            if (item == null)
            {
                throw new EntityNotFoundException(nameof(Item), request.ItemId);
            }

            var viewModel = _mapper.Map<ItemViewModel>(item);

            return viewModel;

        }
    }
}


