
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Api.Application.Commands.Warehouses;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, bool>
{
    private readonly IStorageRepository _storageRepository;

    public CreateLocationCommandHandler(IStorageRepository storageRepository)
    {
        _storageRepository = storageRepository;
    }

    public async Task<bool> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _storageRepository.GetWarehouseById(request.WarehouseId);
        if (warehouse is null)
        {
            throw new EntityNotFoundException(nameof(Warehouse), request.WarehouseId);
        }
        var location = new Location(request.LocationId);

        warehouse.Locations.Add(location);

        await _storageRepository.AddLocation(location);

        return await _storageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
