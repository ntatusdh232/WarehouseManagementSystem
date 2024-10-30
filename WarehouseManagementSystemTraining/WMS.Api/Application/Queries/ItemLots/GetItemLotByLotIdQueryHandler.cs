
namespace WMS.Api.Application.Queries.ItemLots;

public class GetItemLotByLotIdQueryHandler : IRequestHandler<GetItemLotByLotIdQuery, QueryResult<ItemLotViewModel>>
{
    public Task<QueryResult<ItemLotViewModel>> Handle(GetItemLotByLotIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
