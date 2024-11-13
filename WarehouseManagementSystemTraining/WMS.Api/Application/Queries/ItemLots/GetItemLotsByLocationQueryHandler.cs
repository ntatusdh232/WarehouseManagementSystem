namespace WMS.Api.Application.Queries.ItemLots
{
    public class GetItemLotsByLocationQueryHandler : IRequestHandler<GetItemLotsByLocationQuery, IEnumerable<ItemLotViewModel>>
    {

        public Task<IEnumerable<ItemLotViewModel>> Handle(GetItemLotsByLocationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}


