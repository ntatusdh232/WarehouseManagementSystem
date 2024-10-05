namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;

public interface IContainerRepository : IRepository<Container>
{
    Container Add(Container container);
    Container Update(Container container);
    void UpdateRange(IEnumerable<Container> containers);
    void Delete(Container container);
    Task<Container?> GetAsync(string containerId);
}
