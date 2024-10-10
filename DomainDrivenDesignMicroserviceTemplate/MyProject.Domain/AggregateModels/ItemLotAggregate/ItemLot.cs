using MyProject.Domain.AggregateModels.ItemAggregate;
using MyProject.Domain.AggregateModels.LocationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.ItemLotAggregate;

public class ItemLot : Entity, IAggregateRoot
{
    public string LotId { get; private set; }
    public double Quantity { get; private set; }
    public DateTime Timestamp { get; private set; }
    public DateTime? ProdutionDate {get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public bool IsIsolated { get; private set; }
    public Item Item { get; private set; }
    public List<Location> Locations { get; private set; } = new List<Location>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public ItemLot()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
