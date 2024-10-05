using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.EmployeeAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsIssueAggregate;

public class GoodsIssueEntry
{
    public int Id { get; private set; }
    public int GoodsIssueId { get; private set; }
    public int ItemId { get; private set; }
    public Employee Employee { get; private set; }
    public Item Item { get; private set; }
    public double TotalQuantity { get; private set; }
    public List<GoodsIssueEntryContainer> Containers { get; private set; }
    public string? Note { get; private set; }

    private GoodsIssueEntry() { }

    public GoodsIssueEntry(Item item, double totalQuantity, string? note) : this()
    {
        ItemId = item.Id;
        Item = item;
        if (item.Manager is null)
        {
            throw new WarehouseDomainException($"Item {item.ItemId} doesn't have a manager");
        }
        Employee = item.Manager;
        TotalQuantity = totalQuantity;
        Containers = new List<GoodsIssueEntryContainer>();
        Note = note;
    }

    public void AddContainer(Container container, double quantityToTake)
    {
        if (!container.IsFullAndValid())
        {
            var exception = new WarehouseDomainException($"Container with ID {container.Id} is invalid.");
            exception.Data.Add("Container", container);
            throw exception;
        }

#pragma warning disable CS8604 // Possible null reference argument.
        if (container.Item != Item)
#pragma warning restore CS8604 // Possible null reference argument.
        {
            throw new WarehouseDomainException($"Container with ID {container.Id}'s item ({container.Item.Id}) isn't the same with goods issue entry's item ({Item.Id})");
        }

        if (container.Location is null)
        {
            throw new WarehouseDomainException($"Container with ID {container.Id} isn't currently in stock.");
        }

        if (container.ActualQuantity < quantityToTake)
        {
            throw new WarehouseDomainException($"Container with ID {container.Id} contain insufficient ammount of goods: {container.ActualQuantity}. Required: {quantityToTake}");
        }

        GoodsIssueEntryContainer goodsIssueEntryContainer = new(
            container.ContainerId,
            quantityToTake,
#pragma warning disable CS8629 // Nullable value type may be null.
            container.ProductionDate.Value);
#pragma warning restore CS8629 // Nullable value type may be null.

        Containers.Add(goodsIssueEntryContainer);
    }

    public void SetItem(Item item)
    {
        Item = item;
    }
}
