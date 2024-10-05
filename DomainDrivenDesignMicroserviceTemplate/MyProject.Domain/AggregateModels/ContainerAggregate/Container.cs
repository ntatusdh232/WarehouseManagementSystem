using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerTypeAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;

public class Container : Entity, IAggregateRoot
{
    public string ContainerId { get; private set; }
    public double? PlannedQuantity { get; private set; }
    public double? ActualQuantity { get; private set; }
    public DateTime? ProductionDate { get; private set; }
    public bool Consistent { get; private set; }
    public Item? Item { get; private set; }
    public Slot? Location { get; private set; }
    public ContainerType ContainerType { get; private set; }

    private Container() { }

    public Container(string containerId, ContainerType containerType)
    {
        ContainerId = containerId;
        ContainerType = containerType;
    }

    public void UpdatePlannedInformation(double plannedQuantity, DateTime productionDate, Item item)
    {
        PlannedQuantity = plannedQuantity;
        ProductionDate = productionDate;
        Item = item;
    }

    public void UpdateActualQuantity(double actualQuantity)
    {
        ActualQuantity = actualQuantity;
    }

    public void SetStorageSlot(Slot storageSlot)
    {
        if (storageSlot.Container is not null)
        {
            Location = storageSlot;
        }
    }

    public void UpdateConsistency(bool consistent)
    {
        Consistent = consistent;
    }

    public void Clear()
    {
        PlannedQuantity = null;
        ProductionDate = null;
        Item = null;
        ActualQuantity = null;
        Location = null;
    }

    public bool IsFullAndValid()
    {
        bool valid = PlannedQuantity > 0 && ActualQuantity > 0 && Item is not null && ProductionDate is not null;

        return valid;
    }
}
