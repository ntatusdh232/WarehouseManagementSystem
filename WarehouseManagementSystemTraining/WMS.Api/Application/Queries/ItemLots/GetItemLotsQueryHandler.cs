namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotsQueryHandler : IRequestHandler<GetItemLotsQuery, IEnumerable<ItemLotViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetItemLotsQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<ItemLot> _itemLots => _context.itemsLot
            .AsNoTracking()
            .Include(il => il.ItemLotLocations)
            .ThenInclude(ill => ill.Location)
            .Include(il => il.Item);

        public async Task<IEnumerable<ItemLotViewModel>> Handle(GetItemLotsQuery request, CancellationToken cancellationToken)
        {
            var itemLots = await _itemLots
                            .Where(i => i.Item.ItemId == request.itemId)
                            .ToListAsync();

            var itemLotViewModels = _mapper.Map<IEnumerable<ItemLotViewModel>>(itemLots);

            return itemLotViewModels;

        }
    }

}

