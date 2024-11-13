namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotsQueryHandler : IRequestHandler<GetItemLotsQuery, IEnumerable<ItemLotViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ItemLotsQueries itemLotsQueries;

        public GetItemLotsQueryHandler(IMapper mapper, ItemLotsQueries itemLotsQueries)
        {
            _mapper = mapper;
            this.itemLotsQueries = itemLotsQueries;
        }

        public async Task<IEnumerable<ItemLotViewModel>> Handle(GetItemLotsQuery request, CancellationToken cancellationToken)
        {
            var itemLots = await itemLotsQueries._itemLots
                            .Where(i => i.Item.ItemId == request.itemId)
                            .ToListAsync();

            var itemLotViewModels = _mapper.Map<IEnumerable<ItemLotViewModel>>(itemLots);

            return itemLotViewModels;

        }
    }

}

