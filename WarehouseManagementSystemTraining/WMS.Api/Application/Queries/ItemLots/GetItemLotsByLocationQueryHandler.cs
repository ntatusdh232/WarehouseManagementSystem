namespace WMS.Api.Application.Queries.ItemLots;

public class GetItemLotsByLocationQueryHandler : IRequestHandler<GetItemLotsByLocationQuery, IEnumerable<ItemLotViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public GetItemLotsByLocationQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    private IQueryable<ItemLot> _itemLots => _context.itemsLot
    .AsNoTracking()
    .Include(il => il.ItemLotLocations)
    .ThenInclude(ill => ill.Location)
    .Include(il => il.Item);

    public async Task<IEnumerable<ItemLotViewModel>> Handle(GetItemLotsByLocationQuery request, CancellationToken cancellationToken)
    {
        var itemLots = await _itemLots.Where(x => x.ItemLotLocations
                                      .Any(itemLotLocation => itemLotLocation.Location.LocationId == request.LocationId))
                                      .ToListAsync();


        var viewModels = _mapper.Map<IEnumerable<ItemLotViewModel>>(itemLots);

        return viewModels;
    }
}


