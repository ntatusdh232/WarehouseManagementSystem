namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerTypeAggregate;

public interface IContainerTypeRepository: IRepository<ContainerType>
{
    Task<ContainerType?> GetAsync(string containerTypeName);
}
