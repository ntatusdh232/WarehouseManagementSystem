using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.StockCardAggregate;

public class StockCardEntry : Entity, IAggregateRoot
{
    public int ItemId { get; private set; }
    public Item Item { get; private set; }
    public DateTime Date { get; private set; }
    public double BeforeQuantity { get; private set; }
    public double InputQuantity { get; private set; }
    public double OutputQuantity { get; private set; }
    public double AfterQuantity { get; private set; }
    public string Note { get; private set; }

    private StockCardEntry()
    {
    }

    public StockCardEntry(Item item, DateTime date)
    {
        Item = item;
        ItemId = item.Id;
        Date = date;
        BeforeQuantity = 0;
        InputQuantity = 0;
        OutputQuantity = 0;
        Note = "";
    }

    public StockCardEntry(StockChange stockChange, StockCardEntry latestEntry)
    {
        if (stockChange.Item != latestEntry.Item)
        {
            throw new WarehouseDomainException($"Stock change's item({stockChange.Item.ItemId} isn't the same with lastest entry's product({latestEntry.Item.Id}))");
        }

        Item = latestEntry.Item;
        ItemId = latestEntry.ItemId;
        Date = stockChange.Date;
        BeforeQuantity = latestEntry.AfterQuantity;
        AfterQuantity = latestEntry.AfterQuantity;
        InputQuantity = 0;
        OutputQuantity = 0;

        this.UpdateEntry(stockChange);
    }

    public void UpdateEntry(StockChange stockChange)
    {
        if (stockChange.Item != Item || stockChange.Date.Date != Date)
        {
            throw new WarehouseDomainException($"Stock change's item isn't the same with stock card's product.");
        }

        if (stockChange.Quantity > 0)
        {
            InputQuantity += stockChange.Quantity;
        }
        else
        {
            OutputQuantity -= stockChange.Quantity;
        }
        AfterQuantity += stockChange.Quantity;
        Note += stockChange.Note;
    }

    public void SetItem(Item item)
    {
        Item = item;
        ItemId = item.Id;
    }
}
