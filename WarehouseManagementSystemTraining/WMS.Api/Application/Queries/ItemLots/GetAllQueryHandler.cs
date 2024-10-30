
namespace WMS.Api.Application.Queries.ItemLots;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<ItemLotViewModel>>
{
    public Task<IEnumerable<ItemLotViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
