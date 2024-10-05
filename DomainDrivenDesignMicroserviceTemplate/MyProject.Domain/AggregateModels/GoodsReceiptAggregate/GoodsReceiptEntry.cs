using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsReceiptAggregate;

public class GoodsReceiptEntry
{
    public int Id { get; private set; }
    public int GoodsReceiptId { get; private set; }
    public int ItemId { get; private set; }
    public Item Item { get; private set; }
    public double PlannedQuantity { get; private set; }
    public List<GoodsReceiptEntryContainer> Containers { get; private set; }
    public string? Note { get; private set; }

    private GoodsReceiptEntry()
    {
    }

    public GoodsReceiptEntry(Item item, double plannedQuantity, List<GoodsReceiptEntryContainer> containers, string? note)
    {
        Item = item;
        ItemId = item.Id;
        PlannedQuantity = plannedQuantity;
        Containers = containers;
        Note = note;
    }

    public void AddContainer(Container container)
    {
        if (container is null)
        {
            throw new ArgumentNullException(nameof(container));
        }

        if (container.PlannedQuantity is null ||
            container.ActualQuantity is null ||
            container.ProductionDate is null)
        {
            throw new WarehouseDomainException($"Container with id {container.ContainerId} is invalid");
        }

        if (container.Item is null || container.Item != this.Item)
        {
            throw new WarehouseDomainException($"Container with id {container.ContainerId} item isn't the same type with the entry.");
        }

        var entryContainer = new GoodsReceiptEntryContainer(container.ContainerId, container.PlannedQuantity.Value, container.ActualQuantity.Value, container.ProductionDate.Value);
        Containers.Add(entryContainer);
    }

    public void AddContainers(IEnumerable<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }
}
