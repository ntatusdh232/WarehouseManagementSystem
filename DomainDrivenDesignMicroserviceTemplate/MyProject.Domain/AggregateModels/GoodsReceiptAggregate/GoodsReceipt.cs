using ChaWarehouseMicroservice.Domain.AggregateModels.ContainerAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.EmployeeAggregate;
using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsReceiptAggregate;

public class GoodsReceipt : Entity, IAggregateRoot
{
    public string GoodsReceiptId { get; set; }
    public DateTime Timestamp { get; private set; }
    public Employee? Approver { get; private set; }
    public List<GoodsReceiptEntry> Entries { get; private set; }
    public bool Confirmed { get; private set; }

    private GoodsReceipt()
    {
    }

    public GoodsReceipt(string goodsReceiptId, DateTime timestamp, bool confirmed)
    {
        GoodsReceiptId = goodsReceiptId;
        Timestamp = timestamp;
        Entries = new List<GoodsReceiptEntry>();
        Confirmed = confirmed;
    }

    public void AddEntry(Item item, double plannedQuantity, string? note)
    {
        var entry = new GoodsReceiptEntry(item, plannedQuantity, new List<GoodsReceiptEntryContainer>(), note);

        var existed = Entries.Any(e => e.Item == item);

        if (existed)
        {
            throw new WarehouseDomainException($"The item {item.ItemId} has already existed in the goods receipts.");
        }

        Entries.Add(entry);
    }

    private void AddContainer(Container container)
    {
        if (container.Item is null)
        {
            throw new WarehouseDomainException($"The container with id {container.Id} doesn't contain any item");
        }

        var entry = Entries.FirstOrDefault(e => e.Item == container.Item);

        if (entry is null)
        {
            throw new WarehouseDomainException($"The goods receipt {GoodsReceiptId} doesn't contain any item with id {container.Item.Id}.");
        }

        entry.AddContainer(container);
    }

    public void AddContainers(IEnumerable<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }

        this.AddDomainEvent(new ContainersImportedDomainEvent(containers));
    }

    public void Confirm(Employee approver)
    {
        Approver = approver;
        foreach (var entry in Entries)
        {
            var changedQuantity = entry.Containers.Sum(c => c.ActualQuantity);

            StockChange stockChange = new StockChange(entry.Item, Timestamp.Date, changedQuantity, "");
            this.AddDomainEvent(new StockChangedDomainEvent(stockChange));
        }
        Confirmed = true;
    }
}
