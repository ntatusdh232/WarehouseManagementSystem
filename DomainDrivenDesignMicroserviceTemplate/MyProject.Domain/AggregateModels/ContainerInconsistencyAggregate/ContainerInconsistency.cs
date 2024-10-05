using ChaWarehouseMicroservice.Domain.AggregateModels.EmployeeAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerInconsistencyAggregate;

public class ContainerInconsistency : Entity, IAggregateRoot
{
    public DateTime Timestamp { get; private set; }
    public string ContainerId { get; private set; }
    public string StorageSlotId { get; private set; }
    public Item Item { get; private set; }
    public string GoodsIssueId { get; private set; }
    public double CurrentQuantity { get; private set; }
    public double NewQuantity { get; private set; }
    public string Note { get; private set; }
    public bool IsFixed { get; private set; }
    public Employee Reporter { get; private set; }

    private ContainerInconsistency() { }

    public ContainerInconsistency(
        string containerId,
        string storageSlotId,
        Item item,
        string goodsIssueId,
        double currentQuantity,
        Employee reporter)
    {
        ContainerId = containerId;
        StorageSlotId = storageSlotId;
        Item = item;
        GoodsIssueId = goodsIssueId;
        CurrentQuantity = currentQuantity;
        Reporter = reporter;
        Note = "";

        this.AddDomainEvent(new ContainerConsistencyChangedDomainEvent(containerId, false));
    }

    public void Adjust(DateTime timestamp, double newQuantity, string note)
    {
        Timestamp = timestamp;
        NewQuantity = newQuantity;
        Note = note;

        var changedQuantity = newQuantity - CurrentQuantity;
        this.AddDomainEvent(new ContainerContentsChangedDomainEvent(ContainerId, changedQuantity));
        this.AddDomainEvent(new ContainerConsistencyChangedDomainEvent(ContainerId, true));
    }
}
