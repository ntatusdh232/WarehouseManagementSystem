using ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.StockCardAggregate;

public class StockChange
{
    public Item Item { get; private set; }
    public DateTime Date { get; private set; }
    public double Quantity { get; private set; }
    public string Note { get; private set; }

    public StockChange(Item item, DateTime date, double quantity, string note)
    {
        Item = item;
        Date = date;
        Quantity = quantity;
        Note = note;
    }
}
