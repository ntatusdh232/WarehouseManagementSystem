
namespace WMS.Api.Application.Queries.ItemLots;

public class GetIsolatedItemLotsQueryHandler : IRequestHandler<GetIsolatedItemLotsQuery, IEnumerable<ItemLotViewModel>>
{
    public Task<IEnumerable<ItemLotViewModel>> Handle(GetIsolatedItemLotsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
