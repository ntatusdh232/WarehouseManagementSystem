using ChaWarehouseMicroservice.Domain.AggregateModels.EmployeeAggregate;

namespace ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

public class Item : Entity, IAggregateRoot
{
    public string ItemId { get; private set; }
    public string Name { get; private set; }
    public double? PiecesPerKilogram { get; private set; }
    public double MinimumStockLevel { get; private set; }
    public double MaximumStockLevel { get; private set; }
    public EUnit? Unit { get; private set; }
    public EItemSource? ItemSource { get; private set; }
    public Employee Manager { get; private set; }

    private Item()
    {
    }

    public Item(string itemId, string name, double piecesPerKilogram, double minimumStockLevel, double maximumStockLevel, EUnit unit, EItemSource itemSource, Employee manager)
    {
        ItemId = itemId;
        Name = name;
        PiecesPerKilogram = piecesPerKilogram;
        MinimumStockLevel = minimumStockLevel;
        MaximumStockLevel = maximumStockLevel;
        Unit = unit;
        ItemSource = itemSource;
        Manager = manager;
    }

    public Item(string itemId, string name, double piecesPerKilogram, double minimumStockLevel, double maximumStockLevel)
    {
        ItemId = itemId;
        Name = name;
        PiecesPerKilogram = piecesPerKilogram;
        MinimumStockLevel = minimumStockLevel;
        MaximumStockLevel = maximumStockLevel;
    }

    public void ConfirmCreation()
    {
        AddDomainEvent(new ItemCreatedDomainEvent(this));
    }

    public void Update(string itemId, string name, double piecesPerKilogram, double minimumStockLevel, double maximumStockLevel, EUnit unit, EItemSource itemSource, Employee manager)
    {
        ItemId = itemId;
        Name = name;
        PiecesPerKilogram = piecesPerKilogram;
        MinimumStockLevel = minimumStockLevel;
        MaximumStockLevel = maximumStockLevel;
        Unit = unit;
        ItemSource = itemSource;
        Manager = manager;
    }
}