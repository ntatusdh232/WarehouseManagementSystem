using MyProject.Domain.AggregateModels.ItemClassAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.ItemAggregate;

public class Item : Entity, IAggregateRoot
{
    public string ItemId { get; private set; }
    public string ItemName { get; private set; }
    public string Unit {  get; private set; }
    public double MinimumStockLevel { get; private set; }
    public decimal Price { get; private set; }
    public double? PacketSize { get; private set; }
    public string? PacketUnit {  get; private set; }
    public ItemClass ItemClass { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Item()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public void Update(string unit, double minimumStockLevel, decimal price)
    { }
}
