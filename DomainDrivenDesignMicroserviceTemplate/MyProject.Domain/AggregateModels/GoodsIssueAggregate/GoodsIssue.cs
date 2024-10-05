using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.StockCardAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsIssueAggregate;

public class GoodsIssue : Entity, IAggregateRoot
{
    public string GoodsIssueId { get; private set; }
    public DateTime Timestamp { get; private set; }
    public bool Confirmed { get; private set; }
    public List<GoodsIssueEntry> Entries { get; private set; }

    private GoodsIssue() { }

    public GoodsIssue(string goodsIssueId, DateTime timestamp) : this()
    {
        GoodsIssueId = goodsIssueId;
        Timestamp = timestamp;
        Entries = new List<GoodsIssueEntry>();
    }

    public void AddEntry(Item item, double totalQuantity, string? note)
    {
        var entry = new GoodsIssueEntry(item, totalQuantity, note);
        foreach (var existedEntry in Entries)
        {
            if (entry.Item == existedEntry.Item)
            {
                throw new WarehouseDomainException($"Entry with item with ID {entry?.Item?.ItemId} is already in the goods issue.");
            }
        }

        Entries.Add(entry);
    }

    public void AddContainer(Container container, double quantityToTake)
    {
        if (!container.IsFullAndValid())
        {
            throw new WarehouseDomainException("Container is empty.");
        }

#pragma warning disable CS8604 // Possible null reference argument.
        var entryToAdd = Entries.FirstOrDefault(e => e.Item == container.Item);
#pragma warning restore CS8604 // Possible null reference argument.

        if (entryToAdd is null)
        {
            throw new WarehouseDomainException($"Item with ID {container?.Item?.ItemId} isn't currently in the goods issue.");
        }

        entryToAdd.AddContainer(container, quantityToTake);
    }

    public void ExportContainers(List<Container> containers)
    {
        var completelyExportedContainers = new List<Container>();
        foreach (var container in containers)
        {
            var goodsIssueContainer = Entries.SelectMany(e => e.Containers).First(c => c.ContainerId == container.ContainerId);

            goodsIssueContainer.Export();
            this.AddDomainEvent(new ContainerContentsChangedDomainEvent(goodsIssueContainer.ContainerId, -goodsIssueContainer.Quantity));

            if (goodsIssueContainer.Quantity == container.ActualQuantity)
            {
                completelyExportedContainers.Add(container);
            }
        }
        this.AddDomainEvent(new ContainersExportedDomainEvent(completelyExportedContainers));


        if (!Entries.Any(e => e.Containers.Any(c => c.IsTaken == false)))
        {
            Confirmed = true;
            foreach (var entry in Entries)
            {
                var stockChangeValue = entry.Containers.Sum(c => c.Quantity);

                var stockChange = new StockChange(entry.Item, Timestamp.Date, -stockChangeValue, "");
                this.AddDomainEvent(new StockChangedDomainEvent(stockChange));
            }
        }
    }
}
