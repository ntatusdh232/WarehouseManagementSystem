namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerInconsistencyAggregate;

public interface IContainerInconsistencyRepository: IRepository<ContainerInconsistency>
{
    ContainerInconsistency Add(ContainerInconsistency containerInconsistency);
    ContainerInconsistency Update(ContainerInconsistency containerInconsistency);
    Task<IEnumerable<ContainerInconsistency>> GetListAsync(bool adjusted);
    Task<ContainerInconsistency?> GetAsync(string containerId, DateTime timestamp);
}
