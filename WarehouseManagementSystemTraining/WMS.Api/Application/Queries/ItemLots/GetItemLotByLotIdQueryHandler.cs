namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotByLotIdQueryHandler : IRequestHandler<GetItemLotByLotIdQuery, QueryResult<ItemLotViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetItemLotByLotIdQueryHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<ItemLot> _itemLots => _context.itemsLot
            .AsNoTracking()
            .Include(il => il.ItemLotLocations)
            .ThenInclude(ill => ill.Location)
            .Include(il => il.Item);

        public async Task<QueryResult<ItemLotViewModel>> Handle(GetItemLotByLotIdQuery request, CancellationToken cancellationToken)
        {
            var itemLot =  await _itemLots.FirstOrDefaultAsync(i => i.LotId == request.LotId);

            var itemLotViewModel = _mapper.Map<QueryResult<ItemLotViewModel>>(itemLot);

            return itemLotViewModel;


        }
    }
}


