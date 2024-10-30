
namespace WMS.Api.Application.Queries.ItemLots;

public class GetItemLotsQueryHandler : IRequestHandler<GetItemLotsQuery, IEnumerable<ItemLotViewModel>>
{
    public Task<IEnumerable<ItemLotViewModel>> Handle(GetItemLotsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
