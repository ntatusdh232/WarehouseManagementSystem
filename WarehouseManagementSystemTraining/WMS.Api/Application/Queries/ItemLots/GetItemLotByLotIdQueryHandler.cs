namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotByLotIdQueryHandler : IRequestHandler<GetItemLotByLotIdQuery, QueryResult<ItemLotViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ItemLotsQueries itemLotsQueries;

        public GetItemLotByLotIdQueryHandler(IMapper mapper, ItemLotsQueries itemLotsQueries)
        {
            _mapper = mapper;
            this.itemLotsQueries = itemLotsQueries;
        }

        public async Task<QueryResult<ItemLotViewModel>> Handle(GetItemLotByLotIdQuery request, CancellationToken cancellationToken)
        {
            var itemLot =  await itemLotsQueries._itemLots.FirstOrDefaultAsync(i => i.LotId == request.LotId);

            var itemLotViewModel = _mapper.Map<QueryResult<ItemLotViewModel>>(itemLot);

            return itemLotViewModel;


        }
    }
}


