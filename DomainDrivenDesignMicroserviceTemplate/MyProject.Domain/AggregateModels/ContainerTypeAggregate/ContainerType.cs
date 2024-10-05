namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerTypeAggregate;
public class ContainerType: IAggregateRoot
{
    public string Name { get; private set; }
    public double Weight { get; private set; }

    public ContainerType(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
}

