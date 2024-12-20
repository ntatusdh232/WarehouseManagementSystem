﻿
namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<ItemLotViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IItemLotRepository _itemLotRepository;

        public GetAllQueryHandler(IMapper mapper, ApplicationDbContext context, IItemLotRepository itemLotRepository)
        {
            _mapper = mapper;
            _context = context;
            _itemLotRepository = itemLotRepository;
        }

        private IQueryable<ItemLot> _itemLots => _context.itemsLot
        .AsNoTracking()
        .Include(il => il.ItemLotLocations)
        .ThenInclude(ill => ill.Location)
        .Include(il => il.Item);

        public async Task<IEnumerable<ItemLotViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var itemLots = await _itemLots.ToListAsync();

            var viewModels = _mapper.Map<IEnumerable<ItemLotViewModel>>(itemLots);

            return viewModels;
        }
    }

}

